
///*************************************************************************/
///*
///* 文件名    ：AttachFile_Bridge.cs
///*
///* 程序说明  : 单据附件管理数据层桥接单元
///* 原创作者  ：孙中吕 
///* 
///* Copyright 2010-2011 C/S框架网 www.csframework.com
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSFramework3.Interfaces.Interfaces_Bridge;
using CSFramework.Core;
using CSFramework.Common;
using System.Data;
using System.ServiceModel;
using CSFramework3.WebServiceReference;
using CSFramework3.Server.DataAccess.DAL_System;
using CSFramework3.WebServiceReference.WCF_CommonService;

namespace CSFramework3.Bridge.SystemModule
{
    public class ADODirect_AttachFile
    {
        private IBridge_AttachFile _DAL_Instance = null;//数据层实例

        public ADODirect_AttachFile()
        {
            _DAL_Instance = new dalAttachFile(Loginer.CurrentUser);
        }

        public IBridge_AttachFile GetInstance()
        {
            return _DAL_Instance;
        }
    }

    public class WebService_AttachFile : IBridge_AttachFile
    {
        public WebService_AttachFile()
        {
        }

        #region IBridge_AttachFile Members

        public System.Data.DataTable GetData(string docID)
        {
            using (CommonServiceClient client = SoapClientFactory.CreateCommonServiceClient())
            {
                byte[] loginTicket = WebServiceSecurity.EncryptLoginer(Loginer.CurrentUser);
                byte[] receivedData = client.GetAttachedFiles(loginTicket, docID);
                return ZipTools.DecompressionDataSet(receivedData).Tables[0];
            }
        }

        #endregion
    }
}
