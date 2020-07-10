using MRecon.Database;
using MRecon.AbstractFactory;
using MRecon.Model;
using MRecon.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.SQLConnectionFactory
{
    public class RegistrationBAL : IRegistration
    {
        DbModel db;
        public RegistrationBAL()
        {
            db = new DbModel();
        }

        List<Model.RegistrationMaster> IRegistration.GetRegistraionDetails()
        {
            return db.RegistrationMasters.Where(x => x.IsActive == true).ToList();
        }

        List<Model.RegistrationMaster> IRegistration.GetRegistraionDetails(long RegistrationID)
        {
            return db.RegistrationMasters.Where(x => x.IsActive == true).ToList();
        }


        bool IRegistration.LicenseDeactivation(Model.RegistrationMaster _Reg)
        {
            try
            {
                _Reg.IsActive = false;
                _Reg.IsActivated = false;
                _Reg.ModifiedBy = 1;
                _Reg.ModifiedDtTm = DateTime.Now;
                db.Entry(_Reg).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }


        List<Model.RegistrationMaster> IRegistration.GetALLRegistraionDetails()
        {
            return db.RegistrationMasters.ToList();
        }

        bool IRegistration.AdditionalSystemRegistration(Model.RegistrationMaster _Reg, ViewModel.LicenseViewModel licvm)
        {
            Int64 RegistrationID = 0;
            string MacAddress = AppUtility.GetMachineData("MacAddress");
            string SystemName = System.Net.Dns.GetHostName();
            var _ExistLicense = db.LicenseKeys.Where(w => w.RegistrationID == _Reg.RegistrationID && w.DesktopName == SystemName && w.MacAddress == MacAddress).ToList();
            if (_ExistLicense.Count == 0)
            {
                var _ExistReg = db.RegistrationMasters.Where(w => w.RegistrationID == _Reg.RegistrationID).ToList();
                foreach (var item in _ExistReg)
                {
                    RegistrationID = item.RegistrationID;
                    if (licvm.IsActivated == true)
                    {
                        item.LicenseUsed = item.LicenseUsed + 1;
                        item.ModifiedBy = _Reg.CreatedBy;
                        item.ModifiedDtTm = DateTime.Now;
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    break;
                }
                LicenseKeys key = new LicenseKeys();
                key.CreatedBy = _Reg.CreatedBy;
                key.CreatedDtTm = DateTime.Now;
                key.DesktopName = SystemName;
                key.IpAddress = "";
                key.IsActive = true;
                key.LicenseKeyCode = licvm.ActivationKey;
                key.LicenseKeySequence = 1;
                key.MacAddress = MacAddress;
                key.RegistrationDtTm = licvm.ActivationDtTm;
                key.RegistrationID = RegistrationID;
                key.ValidUptoDtTm = licvm.ActivationUptoDtTm;
                db.LicenseKeys.Add(key);
                db.SaveChanges();
            }
            return true;
        }

        Int64 IRegistration.AdminUserCreateAndRoleMapping(RegistrationMaster _Reg, ViewModel.LicenseViewModel licvm)
        {
            Int64 RegistrationID = 0;
            //Updating R egistraionDetails
            var _ExistReg = db.RegistrationMasters.Where(w => w.RegistrationID == _Reg.RegistrationID).ToList();
            foreach (var item in _ExistReg)
            {
                RegistrationID = item.RegistrationID;
                if (licvm.IsActivated == true)
                {
                    item.IsActivated = licvm.IsActivated;
                    item.ActivationKey = licvm.ActivationKey;
                    item.ActivatedDtTm = licvm.ActivationDtTm;
                    item.ActivatedTillDtTm = licvm.ActivationUptoDtTm;
                    item.LicenseCount = licvm.SystemCount;
                    item.LicenseUsed = 1;
                    item.ModifiedBy = _Reg.CreatedBy;
                    item.ModifiedDtTm = DateTime.Now;
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
                break;
            }

            foreach (var item in licvm.ServiceList)
            {
                var serviceupdate = db.RegistrationWiseSearchTypes.Where(w => w.RegistrationID == _Reg.RegistrationID && w.SearchTypeID == item.ServiceID).First();
                serviceupdate.IsActivated = item.IsActivated;
                serviceupdate.ActivatedDtTm = licvm.ActivationDtTm;
                db.Entry(serviceupdate).State = EntityState.Modified;
                db.SaveChanges();
            }

            //License Info Update
            string MacAddress = AppUtility.GetMachineData("MacAddress");
            string SystemName = System.Net.Dns.GetHostName();
            var _ExistLicense = db.LicenseKeys.Where(w => w.RegistrationID == _Reg.RegistrationID && w.DesktopName == SystemName && w.MacAddress == MacAddress).ToList();
            if (_ExistLicense.Count == 0)
            {
                LicenseKeys key = new LicenseKeys();
                key.CreatedBy = 1;
                key.CreatedDtTm = DateTime.Now;
                key.DesktopName = licvm.SystemName;
                key.IpAddress = "";
                key.IsActive = true;
                key.LicenseKeyCode = licvm.ActivationKey;
                key.LicenseKeySequence = 1;
                key.MacAddress = licvm.MacAddress;
                key.RegistrationDtTm = licvm.ActivationDtTm;
                key.RegistrationID = RegistrationID;
                key.ValidUptoDtTm = licvm.ActivationUptoDtTm;
                db.LicenseKeys.Add(key);
                db.SaveChanges();
            }

            RoleMaster role = new RoleMaster();
            var _ExistRole = db.RoleMasters.Where(w => w.RoleName == "Super Admin").ToList();
            if (_ExistRole.Count > 0)
            {
                foreach (var item in _ExistRole)
                {
                    role = item;
                    break;
                }
            }
            else
            {
                role.CreatedBy = 1;
                role.CreatedDtTm = DateTime.Now;
                role.IsActive = true;
                role.RoleName = "Super Admin";
                db.RoleMasters.Add(role);
                db.SaveChanges();
            }
            var pages = db.PageMasters.ToList();
            foreach (var page in pages)
            {
                RolePageMapping mapping = new RolePageMapping();
                var _Existmapping = db.RolePageMappings.Where(w => w.PageID == page.PageID && w.RoleID == role.RoleID).ToList();
                if (_Existmapping.Count == 0)
                {
                    mapping.CreatedBy = 1;
                    mapping.CreatedDtTm = DateTime.Now;
                    mapping.IsActive = true;
                    mapping.PageID = page.PageID;
                    mapping.RoleID = role.RoleID;
                    db.RolePageMappings.Add(mapping);
                    db.SaveChanges();
                }
            }
            UserMaster user = new UserMaster();
            var _Existuser = db.UserMasters.Where(w => w.RoleID == role.RoleID).ToList();
            if (_Existuser.Count == 0)
            {
                user.CreatedBy = 1;
                user.CreatedDtTm = DateTime.Now;
                user.IsActive = true;
                user.EmailID = _Reg.EmailID;
                user.FullName = _Reg.Name;
                user.ManagerID = null;
                user.MobileNo = _Reg.MobileNo;
                user.Password = _Reg.MobileNo;
                user.RoleID = role.RoleID;
                user.UserName = _Reg.MobileNo;
                user.ConfirmPassword = _Reg.MobileNo;
                db.UserMasters.Add(user);
                db.SaveChanges();
            }
            else
            {
                foreach (var item in _Existuser)
                {
                    user = item;
                    break;
                }
            }
            return user.UserID;
        }


        Int64 IRegistration.FirstTimeRegistration(string CompanyName, int LicenseCount, string EmailID, string Key, string SystemName, string MacAddress, string Name, string MobileNo, List<Service> SearchTypeList)
        {
            RegistrationMaster _Reg = new RegistrationMaster();
            _Reg.CompanyName = CompanyName;
            _Reg.LicenseCount = Convert.ToInt32(LicenseCount);
            _Reg.CreatedBy = 1;
            _Reg.CreatedDtTm = DateTime.Now;
            _Reg.EmailID = EmailID;
            _Reg.IsActive = true;
            _Reg.Key = Key;
            _Reg.SystemName = SystemName;
            _Reg.MacAddress = MacAddress;
            _Reg.Name = Name;
            _Reg.MobileNo = MobileNo;
            _Reg.IsSentForRegistration = true;
            db.RegistrationMasters.Add(_Reg);
            db.SaveChanges();
            foreach (var item in SearchTypeList)
            {
                RegistrationWiseSearchTypes reg = new RegistrationWiseSearchTypes();
                reg.CreatedBy = 1;
                reg.CreatedDtTm = DateTime.Now;
                reg.IsActive = true;
                reg.RegistrationID = _Reg.RegistrationID;
                reg.IsRequired = item.IsRequired;
                reg.SearchTypeID = item.ServiceID;
                db.RegistrationWiseSearchTypes.Add(reg);
                db.SaveChanges();
            }
            return _Reg.RegistrationID;
        }


        RegistrationMaster IRegistration.GetSingleRegistraionDetail(string Key)
        {
            return db.RegistrationMasters.Where(w => w.Key == Key && w.IsActive == true).FirstOrDefault();
        }
    }
}
