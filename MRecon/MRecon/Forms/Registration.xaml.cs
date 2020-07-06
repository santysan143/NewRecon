using MRecon.Database;
using MRecon.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utility;

namespace MRecon.Forms
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    /// 
    public partial class Registration : Page
    {
        DbModel db = new DbModel();
        Int64 PageLogID;
        public Registration()
        {
            InitializeComponent();            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //Page Logger
                PageLogID = AppUtility.PageLogger(1, 1);
                // Page Event Logger
                AppUtility.PageEventLogger(PageLogID, "Constructor", 1, "Form Load", "Normal");
                //Initiliazing Frame

                //Getting System Info
                string SystemName = System.Net.Dns.GetHostName();
                string MacAddress = AppUtility.GetMachineData("MACAddress");
                //Validating Data
                var items = db.RegistrationMasters.Where(x => x.SystemName == SystemName && x.MacAddress == MacAddress).ToList();
                string PageName = "Forms/Login.xaml";
                foreach (var dd in items)
                {
                    if (dd.IsActivated == true && dd.IsSentForRegistration == true)
                    {
                        // Page Event Logger
                        AppUtility.PageEventLogger(PageLogID, "Constructor", 1, "Sent To Login Page", "Normal");                        
                        break;
                    }
                    else if (dd.IsActivated == false && dd.IsSentForRegistration == true)
                    {
                        PageName = "Forms/Activation.xaml";
                        // Page Event Logger
                        AppUtility.PageEventLogger(PageLogID, "Constructor", 1, "Mail Process Triggerred Again", "Normal");
                        AppUtility.SendRegistrationMail(dd);
                        MessageBox.Show("Please send mail again for activation key.");
                        Frame MainFrame = AppUtility.FindChild<Frame>(Application.Current.MainWindow, "MainFrame");
                        MainFrame.Navigate(new System.Uri(PageName, UriKind.RelativeOrAbsolute));
                        break;
                    }
                }
                
                // Page Event Logger
                AppUtility.PageEventLogger(PageLogID, "Constructor", 1, "Form Load END", "Normal");
            }
            catch (Exception ex)
            {
                // Page Event Logger
                AppUtility.PageEventLogger(PageLogID, "Submit Button", 1, ex.Message + " | " + ex.StackTrace, "Error");
                MessageBox.Show("There is some error, Please contact administrator.");
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Page Event Logger
                AppUtility.PageEventLogger(PageLogID, "Submit Button", 1, "Registration Button Click Started", "Normal");
                RegistrationMaster _Reg = new RegistrationMaster();
                _Reg.CreatedBy = 1;
                _Reg.CreatedDtTm = DateTime.Now;
                _Reg.EmailID = txtEmailID.Text;
                _Reg.IsActive = true;
                _Reg.Key = Guid.NewGuid().ToString();
                _Reg.SystemName = System.Net.Dns.GetHostName();
                _Reg.MacAddress = AppUtility.GetMachineData("MACAddress");
                _Reg.Name = txtFullName.Text;
                _Reg.MobileNo = txtMobileNumber.Text;
                _Reg.IsSentForRegistration = true;
                db.RegistrationMasters.Add(_Reg);
                db.SaveChanges();
                // Page Event Logger
                AppUtility.PageEventLogger(PageLogID, "Submit Button", 1, "Registration Done", "Normal");
                if (_Reg.RegistrationID > 0)
                {
                    // Page Event Logger
                    AppUtility.PageEventLogger(PageLogID, "Submit Button", 1, "Mailig Process Started", "Normal");
                    AppUtility.SendRegistrationMail(_Reg);
                }

                MessageBox.Show("Please send the mail.");
                Frame MainFrame1 = AppUtility.FindChild<Frame>(Application.Current.MainWindow, "MainFrame");
                MainFrame1.Navigate(new System.Uri("Forms/Activation.xaml", UriKind.RelativeOrAbsolute));
                // Page Event Logger
                AppUtility.PageEventLogger(PageLogID, "Submit Button", 1, "Registration Button Click END", "Normal");
            }
            catch (Exception ex)
            {
                // Page Event Logger
                AppUtility.PageEventLogger(PageLogID, "Submit Button", 1, ex.Message + " | " + ex.StackTrace, "Error");
                MessageBox.Show("There is some error, Please contact administrator.");
            }
        }

       

        

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            AppUtility.UpdatePageLogger(PageLogID);
        }
    }
}
