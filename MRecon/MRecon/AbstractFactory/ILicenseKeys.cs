using MRecon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.AbstractFactory
{
    public interface ILicenseKeys
    {
        List<LicenseKeys> GetLicenseDetail(Int64 RegistrationID);
        List<LicenseKeys> GetLicenseDetail(Int64 RegistrationID, string SystemName);
    }
}
