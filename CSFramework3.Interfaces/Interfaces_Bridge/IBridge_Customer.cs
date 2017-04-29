using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CSFramework3.Interfaces
{
    //客户数据层桥接接口
    public interface IBridge_Customer
    {
        //模糊查询客户数据
        DataTable SearchBy(string CustomerFrom, string CustomerTo, string Name, string Attribute);

        //由客户类别获取客户数据
        DataTable GetCustomerByAttributeCodes(string attributeCodes, bool nameWithCode);

        //模糊查询
        DataTable FuzzySearch(string content);

        //模糊查询
        DataTable FuzzySearch(string attributeCodes, string content);
    }
}
