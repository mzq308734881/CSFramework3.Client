///*************************************************************************/
///*
///* 文件名    ：AttachTool.cs      
///
///* 程序说明  : 单据附件管理工具
///               
///* 原创作者  ：孙中吕 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
using System.Data;
using System.Drawing.Imaging;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using CSFramework.Common;
using CSFramework3.Models;
using CSFramework3.Interfaces;

namespace CSFramework3.Business
{

    /// <summary>
    /// 单据附件管理工具
    /// </summary>
    public class AttachTool
    {
        /// <summary>   
        /// 通过扩展名得到图标和描述   
        /// </summary>   
        /// <param name="ext">扩展名</param>   
        /// <param name="LargeIcon">得到大图标</param>   
        /// <param name="smallIcon">得到小图标</param>   
        public static void GetExtsIconAndDescription(string ext, out Icon largeIcon, out Icon smallIcon, out string description)
        {
            largeIcon = smallIcon = null;
            description = "";
            var extsubkey = Registry.ClassesRoot.OpenSubKey(ext);   //从注册表中读取扩展名相应的子键   
            if (extsubkey != null)
            {
                var extdefaultvalue = (string)extsubkey.GetValue(null);     //取出扩展名对应的文件类型名称   
                var typesubkey = Registry.ClassesRoot.OpenSubKey(extdefaultvalue);  //从注册表中读取文件类型名称的相应子键   
                if (typesubkey != null)
                {
                    description = (string)typesubkey.GetValue(null);   //得到类型描述字符串   
                    var defaulticonsubkey = typesubkey.OpenSubKey("DefaultIcon");  //取默认图标子键   
                    if (defaulticonsubkey != null)
                    {
                        //得到图标来源字符串   
                        var defaulticon = (string)defaulticonsubkey.GetValue(null); //取出默认图标来源字符串   
                        var iconstringArray = defaulticon.Split(',');
                        int nIconIndex = 0;
                        if (iconstringArray.Length > 1) int.TryParse(iconstringArray[1], out nIconIndex);
                        //得到图标   
                        System.IntPtr phiconLarge = new IntPtr();
                        System.IntPtr phiconSmall = new IntPtr();
                        ExtractIconExW(iconstringArray[0].Trim('"'), nIconIndex, ref phiconLarge, ref phiconSmall, 1);
                        if (phiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(phiconLarge);
                        if (phiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(phiconSmall);
                    }
                }
            }
        }

        /// <summary>
        /// 获取缺省图标
        /// </summary>
        /// <param name="largeIcon"></param>
        /// <param name="smallIcon"></param>
        public static void GetDefaultIcon(out Icon largeIcon, out Icon smallIcon)
        {
            largeIcon = smallIcon = null;
            System.IntPtr phiconLarge = new IntPtr();
            System.IntPtr phiconSmall = new IntPtr();
            ExtractIconExW(Path.Combine(Environment.SystemDirectory, "shell32.dll"), 0, ref phiconLarge, ref phiconSmall, 1);
            if (phiconLarge.ToInt32() > 0) largeIcon = Icon.FromHandle(phiconLarge);
            if (phiconSmall.ToInt32() > 0) smallIcon = Icon.FromHandle(phiconSmall);
        }

        ///Return Type: UINT->unsigned int   
        ///lpszFile: LPCWSTR->WCHAR*   
        ///nIconIndex: int   
        ///phiconLarge: HICON*   
        ///phiconSmall: HICON*   
        ///nIcons: UINT->unsigned int           
        [DllImportAttribute("shell32.dll", EntryPoint = "ExtractIconExW", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern uint ExtractIconExW([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(UnmanagedType.LPWStr)] string lpszFile, int nIconIndex, ref IntPtr phiconLarge, ref IntPtr phiconSmall, uint nIcons);

        /// <summary>
        /// 获取文件的ICO图标
        /// </summary>
        /// <param name="fileType">文件类型(*.exe,*.dll)</param>
        /// <param name="large">大图标</param>
        /// <param name="small">返回小图标</param>
        public static void CreateFileIcon(string fileType, out Icon large, out Icon small)
        {
            string des;

            if (fileType.Trim() == "")  //预设图标
            {
                AttachTool.GetDefaultIcon(out large, out small);
            }
            else if (fileType.ToUpper() == ".EXE") //应用程序图标单独获取
            {
                IntPtr l = IntPtr.Zero;
                IntPtr s = IntPtr.Zero;

                AttachTool.ExtractIconExW(Path.Combine(Environment.SystemDirectory, "shell32.dll"), 2, ref l, ref s, 1);

                large = Icon.FromHandle(l);
                small = Icon.FromHandle(s);
            }
            else //其它类型的图标
            {
                AttachTool.GetExtsIconAndDescription(fileType, out large, out small, out des);
            }

            if ((large == null) || (small == null)) //无法获取图标,预设图标
                AttachTool.GetDefaultIcon(out large, out small);
        }

        /// <summary>
        /// 由资料行的FileType(文件类型)字段创建图标
        /// </summary>
        /// <param name="sourceRow">资料行</param>
        /// <param name="large">返回的大图标</param>
        /// <param name="small">返回的小图标</param>
        /// <param name="writeRow"></param>
        public static void CreateFileIcon(DataRow sourceRow, out Icon large, out Icon small, bool writeRow)
        {
            string fileType = sourceRow[tb_AttachFile.FileType].ToString();
            CreateFileIcon(fileType, out large, out small);

            if (writeRow)
            {
                DataRowState state = sourceRow.RowState;

                MemoryStream ms1 = new MemoryStream();
                large.ToBitmap().Save(ms1, ImageFormat.Bmp);
                sourceRow[tb_AttachFile.IconLarge] = ms1.ToArray();
                ms1.Close();

                MemoryStream ms2 = new MemoryStream();
                small.ToBitmap().Save(ms2, ImageFormat.Bmp);
                sourceRow[tb_AttachFile.IconSmall] = ms2.ToArray();
                ms2.Close();

                if (state == DataRowState.Unchanged) sourceRow.AcceptChanges();
            }
        }

        /// <summary>
        /// 图像转换为数组
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] ImageToByte(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Bmp);
            byte[] bs = ms.ToArray();
            ms.Close();
            return bs;
        }

        /// <summary>
        /// 数组转换为图像
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        public static Image ByteToImage(byte[] bs)
        {
            MemoryStream ms = new MemoryStream(bs);
            Bitmap bmp = new Bitmap(ms);
            ms.Close();
            return bmp;
        }

    }

    /// <summary>
    /// 图标句柄
    /// </summary>
    [StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct HICON__
    {
        public int unused;
    }

    /// <summary>
    /// 将附件存储在SQLServer
    /// </summary>
    public class AttachmentStorage_SQL : IAttachmentStorage
    {
        /// <summary>
        /// 附件数据表
        /// </summary>
        private DataTable _attachmentStorage = null;

        public AttachmentStorage_SQL()
        { }

        public AttachmentStorage_SQL(DataTable attachmentStorage)
        {
            _attachmentStorage = attachmentStorage;

            DoPrepareDataSource();
        }

        /// <summary>
        /// 准备数据源用于表格显示，主要功能：自动生成显示图标。
        /// </summary>
        public void DoPrepareDataSource()
        {
            if (_attachmentStorage == null) return;

            //临时显示字段
            if (_attachmentStorage.Columns.IndexOf(tb_AttachFile.IconLarge) < 0)
                _attachmentStorage.Columns.Add(tb_AttachFile.IconLarge, typeof(byte[]));

            if (_attachmentStorage.Columns.IndexOf(tb_AttachFile.IconSmall) < 0)
                _attachmentStorage.Columns.Add(tb_AttachFile.IconSmall, typeof(byte[]));

            Icon large;
            Icon small;
            foreach (DataRow R in _attachmentStorage.Rows)
            {
                if (R.RowState == DataRowState.Deleted) continue;
                if (R[tb_AttachFile.IconSmall] != DBNull.Value) continue;
                AttachTool.CreateFileIcon(R, out large, out small, true); //创建图标,用于表格显示
            }
        }

        #region IAttachmentStorage Members

        public DataTable AttachmentStorage
        {
            get { return _attachmentStorage; }
            set
            {
                _attachmentStorage = value;
                this.DoPrepareDataSource();
            }
        }

        public void Save() { }

        private void DeleteAll()
        {
            foreach (DataRow R in _attachmentStorage.Rows) R.Delete();
        }

        private byte[] GetFile(string fileName)
        {
            DataRow[] rows = _attachmentStorage.Select("FileName='" + fileName + "'");
            if (rows.Length > 0)
                return (byte[])rows[0][tb_AttachFile.FileBody];
            else
                return null;
        }
        /// <summary>
        /// 调用相关程序打开附件
        /// </summary>
        public void OpenFile(string fileName)
        {
            DataRow[] rows = _attachmentStorage.Select("FileName='" + fileName + "'");
            if (rows.Length > 0)
            {
                //调用线程打开文件
                Thread td = new Thread(new ParameterizedThreadStart(DoOpenFile));
                td.Start(rows[0]);
            }
            else Msg.Warning("没有选择附件!");
        }

        public void DeleteFile(string fileName)
        {
            DataRow[] rows = _attachmentStorage.Select("FileName='" + fileName + "'");
            if (rows.Length > 0) rows[0].Delete();
        }

        public bool Exists(string fileName)
        {
            DataRow[] rows = _attachmentStorage.Select("FileName='" + fileName + "'");
            return rows.Length > 0;
        }

        public void SaveAs(string fileName)
        {
            DataRow[] rows = _attachmentStorage.Select("FileName='" + fileName + "'");
            if (rows.Length > 0)
            {
                try
                {
                    DataRow R = rows[0];
                    byte[] file = (byte[])R["FileBody"]; //取文件内容
                    string tempFile = CreateTempFile(file as byte[], R["FileName"].ToString());

                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.FileName = R["FileName"].ToString();
                    if (DialogResult.OK == dlg.ShowDialog())
                    {
                        File.Copy(tempFile, dlg.FileName, true);
                        Msg.ShowInformation("保存成功！文件：" + dlg.FileName);
                    }

                    File.Delete(tempFile);
                }
                catch
                {
                    Msg.Warning("无法打开附件, 没有找到可以打开附件的程序！");
                }
            }
            else Msg.Warning("没有选择附件!");
        }

        public void AddFile(object file)
        {
            TAttachFile f = file as TAttachFile;
            DataRow row = _attachmentStorage.NewRow();
            row[tb_AttachFile.DocID] = "";
            row[tb_AttachFile.FileTitle] = f.FileTitle;
            row[tb_AttachFile.FileName] = f.FileName;
            row[tb_AttachFile.FileType] = f.FileType;
            row[tb_AttachFile.FileSize] = f.FileSize;
            row[tb_AttachFile.FileBody] = f.FileBody;
            row[tb_AttachFile.IsDroped] = f.IsDroped;
            row[tb_AttachFile.IconLarge] = f.IconLarge;
            row[tb_AttachFile.IconSmall] = f.IconSmall;
            _attachmentStorage.Rows.Add(row);
        }

        public void AddFile(string fileFullName)
        {
            FileStream fs = null;

            try
            {
                string ext = Path.GetExtension(fileFullName);//扩展名
                string fileName = Path.GetFileName(fileFullName);//显示文件名称

                fs = new FileStream(fileFullName, FileMode.Open);
                byte[] bs = new byte[fs.Length]; //文件内容
                fs.Read(bs, 0, (int)fs.Length);//读取文件内容
                decimal size = decimal.Round((decimal)(fs.Length / 1024.00), 2);//文件大小 kb                
                fs.Close();

                //显示文件的图标
                Icon large;
                Icon small;
                AttachTool.CreateFileIcon(ext, out large, out small);//获取文件的图标

                TAttachFile file = new TAttachFile(); //附件对象
                file.FileName = fileName;
                file.FileTitle = fileName;//文件标题
                file.FileType = ext;////扩展名
                file.FileSize = size;
                file.FileBody = bs;
                file.IconLarge = AttachTool.ImageToByte(large.ToBitmap()); //大图标
                file.IconSmall = AttachTool.ImageToByte(small.ToBitmap()); //小图标

                this.AddFile(file); //保存数据
            }
            catch
            {
                if (fs != null) fs.Close();
            }

        }

        public void UpdateFile(object file)
        {
            TAttachFile f = file as TAttachFile;
            DataRow[] rows = _attachmentStorage.Select("FileID=" + f.FileID.ToString());//查找旧记录
            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                row[tb_AttachFile.DocID] = "";
                row[tb_AttachFile.FileTitle] = f.FileTitle;
                row[tb_AttachFile.FileName] = f.FileName;
                row[tb_AttachFile.FileType] = f.FileType;
                row[tb_AttachFile.FileSize] = f.FileSize;
                row[tb_AttachFile.FileBody] = f.FileBody;
                row[tb_AttachFile.IsDroped] = f.IsDroped;
                row[tb_AttachFile.IconLarge] = f.IconLarge;
                row[tb_AttachFile.IconSmall] = f.IconSmall;
            }
        }

        #endregion

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="attachmentDataRow">当前选择的文件</param>
        private void DoOpenFile(object attachmentDataRow)
        {
            try
            {
                DataRow R = attachmentDataRow as DataRow;
                byte[] file = (byte[])R[tb_AttachFile.FileBody]; //取文件内容
                string tempFile = CreateTempFile(file as byte[], R[tb_AttachFile.FileName].ToString());
                Process p = Process.Start(tempFile);//打开文件
                p.WaitForExit();
                File.Delete(tempFile);
            }
            catch(Exception ex)
            {
                Msg.ShowException(ex, "无法打开附件, 没有找到可以打开附件的程序！");                
            }
        }

        /// <summary>
        /// 创建临时文件
        /// </summary>
        /// <param name="fileBuffer">文件数据</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        private string CreateTempFile(byte[] fileBuffer, string fileName)
        {
            if ((fileBuffer == null) || (fileBuffer.Length == 0)) 
                throw new CustomException("文件内容为空，无法打开文件！");

            string path = Path.GetTempPath() + @"\" + fileName;
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            fs.Write(fileBuffer, 0, fileBuffer.Length);
            fs.Flush();
            fs.Close();
            return path;
        }
    }

    /// <summary>
    /// 将附件存在共享目录
    /// </summary>
    public class AttachmentStorage_Folder : IAttachmentStorage
    {
        #region IAttachmentStorage Members

        public DataTable AttachmentStorage
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public void Save() { }
        public void DeleteAll()
        {
        }

        public byte[] GetFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public void OpenFile(string fileName)
        {
        }

        public void DeleteFile(string fileName)
        {
        }

        public bool Exists(string fileName)
        { return false; }

        public void AddFile(object file)
        {
        }
        public void AddFile(string fileFullName)
        {
        }
        public void UpdateFile(object file)
        {
        }
        public void SaveAs(string fileName)
        { }
        #endregion
    }

    /// <summary>
    /// 对象工厂
    /// </summary>
    public class AttachmentFactory
    {
        public IAttachmentStorage CreateEmptyStorage()
        {
            //系统
            if (SystemConfig.CurrentConfig.AttachmentStorageType == "SQL")
                return new AttachmentStorage_SQL();
            else
                return new AttachmentStorage_Folder();
        }
    }
}
