using MRecon.Model;
using MRecon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.AbstractFactory
{
    public interface IRegistration
    {
        List<RegistrationMaster> GetRegistraionDetails();
        List<RegistrationMaster> GetRegistraionDetails(Int64 RegistrationID);
        RegistrationMaster GetSingleRegistraionDetail(string Key);
        bool LicenseDeactivation(RegistrationMaster _Reg);
        List<Model.RegistrationMaster> GetALLRegistraionDetails();
        bool AdditionalSystemRegistration(RegistrationMaster _Reg, LicenseViewModel licvm);
        Int64 AdminUserCreateAndRoleMapping(RegistrationMaster _Reg, LicenseViewModel licvm);
        Int64 FirstTimeRegistration(string CompanyName, int LicenseCount, string EmailID, string Key, string SystemName, string MacAddress, string Name, string MobileNo, List<Service> SearchTypeList);
    }
}
