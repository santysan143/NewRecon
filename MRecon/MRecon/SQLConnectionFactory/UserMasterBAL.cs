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
    public class UserMasterBAL : IUserMaster
    {
        DbModel db;
        public UserMasterBAL()
        {
            db = new DbModel();
        }
        List<UserMaster> IUserMaster.GetUsers()
        {
            return db.UserMasters.ToList();
        }

        Int64 IUserMaster.RegisterUser(UserMaster user)
        {
            db.UserMasters.Add(user);
            db.SaveChanges();
            return user.UserID;
        }


        public bool UpdateAdminUser(string UserName, string Password, string ConfirmPassword)
        {
            UserMaster _user = db.UserMasters.Where(w => w.RoleID == 1).FirstOrDefault();
            _user.UserName = UserName;
            _user.Password = Password;
            _user.ConfirmPassword = ConfirmPassword;
            db.Entry(_user).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }


        bool IUserMaster.UpdateAdminUser(UserMaster user)
        {
            throw new NotImplementedException();
        }
    }
}
