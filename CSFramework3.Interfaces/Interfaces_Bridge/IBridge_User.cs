using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CSFramework.Common;

namespace CSFramework3.Interfaces
{
    public interface IBridge_User
    {
        DataTable GetUsers();
        DataTable GetUser(string account);
        DataTable GetUserByNovellID(string novellAccount);
        DataTable GetUserDirect(string account, string DBName);
        DataTable GetUserAuthorities(Loginer user);
        DataTable GetUserGroups(string account);

        bool Update(DataSet ds);
        bool DeleteUser(string account);
        bool ExistsUser(string account);
        bool ModifyPassword(string account, string pwd);
        bool ModifyPwdDirect(string account, string pwd, string DBName);

        void Logout(string account);
        DataTable Login(LoginUser loginUser, char LoginUserType);

        DataSet GetUserReportData(DateTime createDateFrom, DateTime createDateTo);

    }
}
