using MRecon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.AbstractFactory
{
    public interface IUserMaster
    {
        List<UserMaster> GetUsers();
        Int64 RegisterUser(UserMaster user);
        bool UpdateAdminUser(string UserName, string Password, string ConfirmPassword);
        Int64 AddUser(UserMaster role);
        Int64 UpdateUser(UserMaster role);
        bool DeleteUser(UserMaster role);
        bool DeactivateUser(Int64 roleid);
    }
}
