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
        bool UpdateAdminUser(UserMaster user);
    }
}
