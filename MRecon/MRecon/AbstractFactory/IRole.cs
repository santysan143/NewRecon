using MRecon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.AbstractFactory
{
    public interface IRole
    {
        List<RoleMaster> GetRoles();
        Int64 AddRole(RoleMaster role);
        Int64 UpdateRole(RoleMaster role);
        bool DeleteRole(RoleMaster role);
        bool DeactivateRole(Int64 roleid);
    }
}
