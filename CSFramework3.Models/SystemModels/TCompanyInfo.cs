using System;
using System.Collections.Generic;
using System.Text;

namespace CSFramework3.Models
{
    /// <summary>
    /// 公司资料设置
    /// </summary>
    public class TCompanyInfo
    {
        private int _ISID = 0;
        private string _CompanyCode = string.Empty;
        private string _NativeName = string.Empty;
        private string _EnglishName = string.Empty;
        private string _ProgramName = string.Empty;
        private bool _IsSelected = false;
        private DateTime _CreationDate;
        private string _CreatedBy = string.Empty;
        private DateTime _LastUpdateDate;
        private string _LastUpdatedBy = string.Empty;

        public int ISID { get { return _ISID; } set { _ISID = value; } }
        public string CompanyCode { get { return _CompanyCode; } set { _CompanyCode = value; } }
        public string NativeName { get { return _NativeName; } set { _NativeName = value; } }
        public string EnglishName { get { return _EnglishName; } set { _EnglishName = value; } }
        public string ProgramName { get { return _ProgramName; } set { _ProgramName = value; } }
        public bool IsSelected { get { return _IsSelected; } set { _IsSelected = value; } }
        public DateTime CreationDate { get { return _CreationDate; } set { _CreationDate = value; } }
        public DateTime LastUpdateDate { get { return _LastUpdateDate; } set { _LastUpdateDate = value; } }
        public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        public string LastUpdatedBy { get { return _LastUpdatedBy; } set { _LastUpdatedBy = value; } }
    }

}
