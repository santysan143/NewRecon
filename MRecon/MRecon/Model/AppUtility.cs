using MRecon.Database;
using MRecon.AbstractFactory;
using MRecon.SQLConnectionFactory;
using MRecon.ViewModel;
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
        static Int64 RegistrationID;
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

        public static bool AdditionSystemRegistration(RegistrationMaster _Reg, LicenseViewModel licvm)
        {
            try
            {
                return MainWindow._FactoryConnection.Registration().AdditionalSystemRegistration(_Reg, licvm);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Int64 AdminUserCreateAndRoleMapping(RegistrationMaster _Reg, LicenseViewModel licvm)
        {
            return MainWindow._FactoryConnection.Registration().AdminUserCreateAndRoleMapping(_Reg, licvm);
        }

        public static Int64 PageLogger(Int64 PageID, Int64 UserID)
        {
            return MainWindow._FactoryConnection.Logger().PageLogger(UserID, PageID);
        }

        public static void UpdatePageLogger(Int64 PageLogID)
        {
            try
            {
                MainWindow._FactoryConnection.Logger().UpdatePageLogger(PageLogID);
            }
            catch (Exception ex)
            {
                PageEventLogger(PageLogID, "UpdatePageLogger", 1, ex.Message + " | " + ex.StackTrace, "Normal");
            }
        }

        public static void PageEventLogger(Int64 PageLogID, string MethodName, Int64 UserID, string Remarks, string RemarkType)
        {
            MainWindow._FactoryConnection.Logger().PageEventLogger(PageLogID, MethodName, UserID, Remarks, RemarkType);
        }



        public static void SendRegistrationMail(LicenseViewModel _Reg)
        {
            string jsonValue = Newtonsoft.Json.JsonConvert.SerializeObject(_Reg);
            //Key Generation
            string Value = Utility.Utility.Encrypt(jsonValue);
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
