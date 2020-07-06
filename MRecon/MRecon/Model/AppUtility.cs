using MRecon.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MRecon.Model
{
    public static class AppUtility
    {

        public static string GetMachineData(string Address)
        {
            ManagementClass MC = new ManagementClass("Win32_NetworkAdapter");
            ManagementObjectCollection MOCol = MC.GetInstances();
            string _address = "";
            foreach (ManagementObject MO in MOCol)
            {
                if (MO != null)
                {
                    if (MO[Address] != null)
                    {
                        _address = MO[Address].ToString();
                        if (_address != string.Empty)
                            break;
                    }
                }
            }
            return _address;


        }

        public static Int64 AdminUserCreateAndRoleMapping(RegistrationMaster _Reg)
        {
            DbModel db = new DbModel();
            var _ExistReg = db.RegistrationMasters.Where(w => w.RegistrationID == _Reg.RegistrationID).ToList();
            foreach (var item in _ExistReg)
            {
                item.IsActivated = true;
                item.ActivationKey = _Reg.ActivationKey;
                item.ModifiedBy = _Reg.CreatedBy;
                item.ModifiedDtTm = DateTime.Now;
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                break;
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

        public static Int64 PageLogger(Int64 PageID, Int64 UserID)
        {
            DbModel db = new DbModel();
            PageLogMaster log = new PageLogMaster();
            log.CreatedBy = UserID;
            log.CreatedDtTm = DateTime.Now;
            log.IsActive = true;
            log.PageEnteredDtTm = DateTime.Now;
            log.PageID = PageID;
            log.UserID = UserID;
            db.PageLogMasters.Add(log);
            db.SaveChanges();
            return log.LogID;
        }

        public static void UpdatePageLogger(Int64 PageLogID)
        {
            try
            {
                DbModel db = new DbModel();
                var Log = db.PageLogMasters.Where(w => w.LogID == PageLogID).ToList();
                foreach (var item in Log)
                {
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                PageEventLogger(PageLogID, "UpdatePageLogger", 1, ex.Message + " | " + ex.StackTrace, "Normal");
            }
        }

        public static void PageEventLogger(Int64 PageLogID, string MethodName, Int64 UserID, string Remarks, string RemarkType)
        {
            DbModel db = new DbModel();
            PageActionLogMaster logAction = new PageActionLogMaster();
            logAction.CreatedBy = UserID;
            logAction.CreatedDtTm = DateTime.Now;
            logAction.IsActive = true;
            logAction.ActivityStartDtTm = DateTime.Now;
            logAction.LogID = PageLogID;
            logAction.MethodName = MethodName;
            logAction.Remarks = Remarks;
            logAction.RemarkType = RemarkType;
            db.PageActionLogMasters.Add(logAction);
            db.SaveChanges();
        }



        public static void SendRegistrationMail(RegistrationMaster _Reg)
        {
            //Key Generation
            string Value = Utility.Utility.Encrypt(_Reg.Name + "|" + _Reg.MobileNo + "|" + _Reg.EmailID + "|" + _Reg.Key + "|" + _Reg.MacAddress + "|" + _Reg.SystemName);
            var curDir = Directory.GetCurrentDirectory();
            var curPath = curDir + "\\lic.txt";
            var exsitpath = curPath.Replace(".txt", ".rec");
            if (File.Exists(exsitpath))
            {
                File.Delete(exsitpath);
            }
            TextWriter txt = new StreamWriter(curPath);
            txt.Write(Value);
            txt.Close();
            // File Name Change
            File.Move(curPath, System.IO.Path.ChangeExtension(curPath, ".rec"));
            //Mailing
            string mailto = string.Format("mailto:{0}?Subject={1}&Body={2}&Attachment={3}", "santysan143@gmail.com", "License Activation", "Please activate my licence with following key : " + Value + " .", exsitpath);
            Process.Start(mailto);
        }

        public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }
    }
}
