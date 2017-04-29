using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.IO;

namespace CSFramework3.Models
{
    [Serializable]
    public class TAttachmentBody
    {
        private string _FileName = "";
        private byte[] _Content = null;

        public string FileName { get { return _FileName; } set { _FileName = value; } }
        public byte[] Content { get { return _Content; } set { _Content = value; } }

        public void LoadFromFile(string attachedFile)
        {
            FileStream fs = null;
            try
            {
                fs = File.OpenRead(attachedFile);
                _Content = new byte[fs.Length];
                _FileName = Path.GetFileName(attachedFile);
                fs.Read(_Content, 0, _Content.Length);
                fs.Close();
                fs.Dispose();
            }
            catch
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
        }
    }

    [Serializable]
    public class TEmailBody
    {
        private string _UserID = "";
        private string _From = "";
        private string _To = "";
        private string _CC = "";
        private string _BC = "";
        private string _Subject = "";
        private string _Content = "";

        private TAttachmentBody[] _Attachments = null;

        public string UserID { get { return _UserID; } set { _UserID = value; } }

        public string From { get { return _From; } set { _From = value; } }
        public string To { get { return _To; } set { _To = value; } }
        public string CC { get { return _CC; } set { _CC = value; } }
        public string BC { get { return _BC; } set { _BC = value; } }
        public string Subject { get { return _Subject; } set { _Subject = value; } }
        public string Content { get { return _Content; } set { _Content = value; } }

        public TAttachmentBody[] Attachments { get { return _Attachments; } set { _Attachments = value; } }

        public string GetAttachmentFileNames()
        {
            if (_Attachments == null) return "";

            string names = "";
            foreach (TAttachmentBody a in _Attachments)
                names = a.FileName + "," + names;

            return names;
        }
    }
}
