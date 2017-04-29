using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CSFramework3.Interfaces
{
    /// <summary>
    /// 共同数据字典表的数据层桥接接口
    /// </summary>
    public interface IBridge_CommonDataDict
    {
        DataTable SearchBy(int dataType);        
        bool AddCommonType(int code, string name);
        bool DeleteCommonType(int code);
        bool IsExistsCommonType(int code);
    }
}
