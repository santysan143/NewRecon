using MRecon.AbstractFactory;
using MRecon.Database;
using MRecon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.SQLConnectionFactory
{
    public class RoleBAL : IRole
    {
        DbModel db;
        public RoleBAL()
         {
             db = new DbModel();
         }
        List<RoleMaster> IRole.GetRoles()
        {
           return db.RoleMasters.ToList();
        }

        long IRole.AddRole(RoleMaster role)
        {
            db.RoleMasters.Add(role);
            db.SaveChanges();
            return role.RoleID;
        }

        long IRole.UpdateRole(RoleMaster role)
        {
            throw new NotImplementedException();
        }

        long IRole.DeleteRole(long roleid)
        {
            throw new NotImplementedException();
        }

        long IRole.DeactivateRole(long roleid)
        {
            throw new NotImplementedException();
        }
    }
}
