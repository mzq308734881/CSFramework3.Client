using System;
using System.Collections.Generic;
using System.Text;

namespace CSFramework3.Models
{
    public class TAttachFile
    {
        private int _FileID;
        private string _DocID;
        private string _FileTitle;
        private string _FileName;
        private string _FileType;
        private decimal _FileSize;
        private byte[] _FileBody;
        private string _IsDroped;

        private byte[] _IconLarge;
        private byte[] _IconSmall;
        public byte[] IconLarge { get { return _IconLarge; } set { _IconLarge = value; } }
        public byte[] IconSmall { get { return _IconSmall; } set { _IconSmall = value; } }

        public int FileID { get { return _FileID; } set { _FileID = value; } }
        public decimal FileSize { get { return _FileSize; } set { _FileSize = value; } }
        public string DocID { get { return _DocID; } set { _DocID = value; } }
        public string FileTitle { get { return _FileTitle; } set { _FileTitle = value; } }
        public string FileName { get { return _FileName; } set { _FileName = value; } }
        public string FileType { get { return _FileType; } set { _FileType = value; } }
        public string IsDroped { get { return _IsDroped; } set { _IsDroped = value; } }
        public byte[] FileBody { get { return _FileBody; } set { _FileBody = value; } }
    }

}
