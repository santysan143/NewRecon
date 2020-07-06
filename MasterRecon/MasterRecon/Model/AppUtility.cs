using MasterRecon.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MasterRecon.Model
{
    public static class AppUtility
    {

        // public static string GetMachineData(string Address)
        //{
        //    ManagementClass MC = new ManagementClass("Win32_NetworkAdapter");
        //    ManagementObjectCollection MOCol = MC.GetInstances();
        //    string _address = "";
        //    foreach (ManagementObject MO in MOCol)
        //    {
        //        if (MO != null)
        //        {
        //            if (MO[Address] != null)
        //            {
        //                _address = MO[Address].ToString();
        //                if (_address != string.Empty)
        //                    break;
        //            }
        //        }
        //    }
        //    return _address;


        // }

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
