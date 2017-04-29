///*************************************************************************/
///*
///* 文件名    ：SaveResult.cs                                      
///* 程序说明  : 保存数据返回的对象
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace CSFramework.Common
{
    /// <summary>
    /// 保存数据返回的状态
    /// </summary>
    public enum ResultID
    {
        /// <summary>
        /// 保存成功
        /// </summary>
        SUCCESS = 1,

        /// <summary>
        /// 保存失败
        /// </summary>
        FAILED = 0,

        /// <summary>
        /// 操作已取消
        /// </summary>
        CANCELLED = -1
    }

    [Serializable]
    public class SaveResultEx
    {
        private int _ResultID;
        private string _PrimaryKey;
        private string _Tag;

        public SaveResultEx() { }
        public SaveResultEx(int resultID, string primaryKey)
        {
            _ResultID = resultID;
            _PrimaryKey = primaryKey;
        }

        /// <summary>
        /// 主键
        /// </summary>
        public string PrimaryKey
        {
            get { return _PrimaryKey; }
            set { _PrimaryKey = value; }
        }

        /// <summary>
        /// 返回状态
        /// </summary>
        public int Result
        {
            get { return _ResultID; }
            set { _ResultID = value; }
        }

        /// <summary>
        /// 其它特别标记
        /// </summary>
        public string Tag
        {
            get { return _Tag; }
            set { _Tag = value; }
        }

        /// <summary>
        /// 是否保存成功
        /// </summary>
        public bool Success
        {
            get { return _ResultID == (int)ResultID.SUCCESS; }
        }
    }

    /// <summary>
    /// 保存业务单据后返回的对象
    /// </summary>
    [Serializable]
    public class SaveResult
    {
        private int _ResultID;
        private string _DocNo;
        private string _GUID;
        private string _Tag;
        private string _Description;

        /// <summary>
        /// 构造器
        /// </summary>
        public SaveResult() { }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="ID">状态编号</param>
        /// <param name="description">保存数据后返回客户端的消息提示</param>
        public SaveResult(int ID, string description)
        {
            _ResultID = ID;
            _Description = description;
        }

        /// <summary>
        /// 创建一个预设对象
        /// </summary>
        /// <returns></returns>
        public static SaveResult CreateDefault()
        {
            return new SaveResult((int)ResultID.SUCCESS, "保存成功！");
        }

        /// <summary>
        /// 当保存失败时记录系统异常的内容
        /// </summary>
        /// <param name="ex"></param>
        public void SetException(Exception ex)
        {
            _ResultID = (int)ResultID.FAILED;
            _Description += "\n\n" + ex.Message;
        }

        /// <summary>
        /// 是否保存成功
        /// </summary>
        public bool Success
        {
            get { return _ResultID == (int)ResultID.SUCCESS; }
        }

        /// <summary>
        /// 返回状态
        /// </summary>
        public int Result
        {
            get { return _ResultID; }
            set { _ResultID = value; }
        }

        /// <summary>
        /// 其它特别标记
        /// </summary>
        public string Tag
        {
            get { return _Tag; }
            set { _Tag = value; }
        }

        /// <summary>
        /// 业务单据号码
        /// </summary>
        public string DocNo
        {
            get { return _DocNo; }
            set { _DocNo = value; }
        }

        /// <summary>
        /// 保存数据后返回客户端的消息提示
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        /// <summary>
        /// 当记录的主键为GUID时返回本次生成的GUID。
        /// </summary>
        public string GUID
        {
            get { return _GUID; }
            set { _GUID = value; }
        }
    }

}
