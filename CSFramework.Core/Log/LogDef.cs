///*************************************************************************/
///*
///* 文件名    ：LogDef.cs                                
///* 程序说明  : 日志的实体类定义
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace CSFramework.Core.Log
{
    /// <summary>
    /// 日志的实体类
    /// </summary>
    public class LogDef
    {
        private int _isid;
        private string _GUID32;
        private string _LogUser;
        private DateTime _LogDate;
        private LogOPType _OPType;
        private string _DocNo;
        private string _TableName;
        private string _KeyFieldName;
        private bool _IsMaster;
        private IList _Details; //明细

        public LogDef()
        {
            _GUID32 = Guid.NewGuid().ToString().Replace("-", "");
            _Details = new ArrayList();
        }

        public int isid { get { return _isid; } set { _isid = value; } }
        public string GUID32 { get { return _GUID32; } set { _GUID32 = value; } }
        public string LogUser { get { return _LogUser; } set { _LogUser = value; } }
        public DateTime LogDate { get { return _LogDate; } set { _LogDate = value; } }
        public LogOPType OPType { get { return _OPType; } set { _OPType = value; } }
        public string DocNo { get { return _DocNo; } set { _DocNo = value; } }
        public string TableName { get { return _TableName; } set { _TableName = value; } }
        public string KeyFieldName { get { return _KeyFieldName; } set { _KeyFieldName = value; } }
        public bool IsMaster { get { return _IsMaster; } set { _IsMaster = value; } }

        public IList Details { get { return _Details; } }
        public bool HasDetail { get { return _Details.Count > 0; } }

        public void AppendDetail(string tableName, string fieldName, string oldValue, string newValue)
        {
            LogDefDtl dtl = new LogDefDtl();
            dtl.GUID32 = this.GUID32;
            dtl.TableName = tableName;
            dtl.FieldName = fieldName;
            dtl.OldValue = oldValue;
            dtl.NewValue = newValue;
            _Details.Add(dtl);
        }
    }

    /// <summary>
    /// 日志明细表定义
    /// </summary>
    public class LogDefDtl
    {
        private int _isid;
        private string _GUID32;
        private string _TableName;
        private string _FieldName;
        private string _OldValue;
        private string _NewValue;

        public int isid { get { return _isid; } set { _isid = value; } }
        public string GUID32 { get { return _GUID32; } set { _GUID32 = value; } }
        public string TableName { get { return _TableName; } set { _TableName = value; } }
        public string FieldName { get { return _FieldName; } set { _FieldName = value; } }
        public string OldValue { get { return _OldValue; } set { _OldValue = value; } }
        public string NewValue { get { return _NewValue; } set { _NewValue = value; } }
    }


}
