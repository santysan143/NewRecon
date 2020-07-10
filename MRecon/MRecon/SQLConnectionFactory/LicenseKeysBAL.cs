using MRecon.Database;
using MRecon.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.SQLConnectionFactory
{
    class LicenseKeysBAL : ILicenseKeys
    {
        DbModel db;
        public LicenseKeysBAL()
        {
            db = new DbModel();
        }
        List<Model.LicenseKeys> ILicenseKeys.GetLicenseDetail(long RegistrationID)
        {
            return db.LicenseKeys.Where(w => w.RegistrationID == RegistrationID).ToList();
        }
        List<Model.LicenseKeys> ILicenseKeys.GetLicenseDetail(long RegistrationID, string SystemName)
        {
            return db.LicenseKeys.Where(w => w.RegistrationID == RegistrationID && w.DesktopName == SystemName).ToList();
        }
    }
}
