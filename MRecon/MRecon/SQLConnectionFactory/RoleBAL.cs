using MRecon.AbstractFactory;
using MRecon.Database;
using MRecon.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            db.Entry(role).State = EntityState.Modified;
            db.SaveChanges();
            return role.RoleID;
        }

        bool IRole.DeleteRole(RoleMaster role)
        {
            db.RoleMasters.Remove(role);
            db.SaveChanges();
            return true;
        }

        bool IRole.DeactivateRole(long roleid)
        {
            var role = db.RoleMasters.Where(w => w.RoleID == roleid).FirstOrDefault();
            role.IsActive = false;
            db.Entry(role).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
    }
}
