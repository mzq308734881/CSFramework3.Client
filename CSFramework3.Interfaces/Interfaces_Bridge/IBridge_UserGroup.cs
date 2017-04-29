using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CSFramework3.Interfaces.Interfaces_Bridge
{
    public interface IBridge_UserGroup
    {
        DataTable GetAuthorityItem();
        DataTable GetUserGroup();
        DataSet GetUserGroup(string groupCode);
        DataTable GetFormTagCustomName();
        bool CheckNoExists(string groupCode);
        bool DeleteGroupByKey(string groupCode);
        int GetFormAuthority(string account, int moduleID, string menuName);
    }
}
