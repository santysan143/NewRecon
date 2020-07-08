using MRecon.Database;
using MRecon.Model;
using MRecon.ViewModel;
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
        List<Service> SearchTypeList;
        public Registration()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RegistrationGrid.IsEnabled = false;
            Application.Current.Windows[0].Height = this.Height;
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
                var items = db.RegistrationMasters.Where(x => x.IsActive == true).ToList();
                SearchTypeList = db.SearchTypeMasters.Select(s => new Service() { IsActivated = false, IsRequired = false, ServiceID = s.SearchTypeID, ServiceName = s.SearchName }).ToList();
                listBoxSeachType.ItemsSource = SearchTypeList;
                string PageName = "Forms/Login.xaml";
                foreach (var dd in items)
                {
                    if (dd.IsActivated == true && dd.IsSentForRegistration == true)
                    {
                        // Page Event Logger
                        AppUtility.PageEventLogger(PageLogID, "Constructor", 1, "Sent To Login Page", "Normal");
                        break;
                    }
                    else if ((dd.IsActivated == false || dd.IsActivated == null) && dd.IsSentForRegistration == true)
                    {
                        PageName = "Forms/Activation.xaml";
                        // Page Event Logger
                        AppUtility.PageEventLogger(PageLogID, "Constructor", 1, "Mail Process Triggerred Again", "Normal");
                        //Registration details to send
                        LicenseViewModel licvm = new LicenseViewModel();
                        licvm.ServiceList = new List<Service>();
                        licvm.ServiceList.AddRange(db.RegistrationWiseSearchTypes.Join(db.SearchTypeMasters, x => x.SearchTypeID, y => y.SearchTypeID, (x, y) => new { x, y.SearchName }).Where(w => w.x.RegistrationID == dd.RegistrationID).Select(s => new Service() { ServiceID = s.x.SearchTypeID, IsRequired = s.x.IsRequired, IsActivated = false, ServiceName = s.SearchName }).ToList());
                        licvm.CompanyName = dd.CompanyName;
                        licvm.EmailID = dd.EmailID;
                        licvm.Key = dd.Key;
                        licvm.MacAddress = dd.MacAddress;
                        licvm.MobileNo = dd.MobileNo;
                        licvm.Name = dd.Name;
                        licvm.SystemCount = dd.LicenseCount;
                        licvm.SystemName = dd.SystemName;
                        licvm.IsActivated = false;
                        AppUtility.SendRegistrationMail(licvm);
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
            finally
            {
                RegistrationGrid.IsEnabled = true;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                RegistrationGrid.IsEnabled = false;
                //Registration details to send
                LicenseViewModel licvm = new LicenseViewModel();
                licvm.ServiceList = new List<Service>();
                licvm.ServiceList.AddRange(SearchTypeList);
                licvm.CompanyName = txtCompanyName.Text;
                licvm.EmailID = txtEmailID.Text;
                licvm.Key = Guid.NewGuid().ToString();
                licvm.MacAddress = AppUtility.GetMachineData("MACAddress");
                licvm.MobileNo = txtMobileNumber.Text;
                licvm.Name = txtFullName.Text;
                licvm.SystemCount = Convert.ToInt32(txtLicenseCount.Text);
                licvm.SystemName = System.Net.Dns.GetHostName();
                licvm.IsActivated = false;
                // Page Event Logger
                AppUtility.PageEventLogger(PageLogID, "Submit Button", 1, "Registration Button Click Started", "Normal");

                //Registeration of Client
                RegistrationMaster _Reg = new RegistrationMaster();
                _Reg.CompanyName = txtCompanyName.Text;
                _Reg.LicenseCount = Convert.ToInt32(txtLicenseCount.Text);
                _Reg.CreatedBy = 1;
                _Reg.CreatedDtTm = DateTime.Now;
                _Reg.EmailID = txtEmailID.Text;
                _Reg.IsActive = true;
                _Reg.Key = licvm.Key;
                _Reg.SystemName = licvm.SystemName;
                _Reg.MacAddress = licvm.MacAddress;
                _Reg.Name = txtFullName.Text;
                _Reg.MobileNo = txtMobileNumber.Text;
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

                // Page Event Logger
                AppUtility.PageEventLogger(PageLogID, "Submit Button", 1, "Registration Done", "Normal");
                if (_Reg.RegistrationID > 0)
                {
                    // Page Event Logger
                    AppUtility.PageEventLogger(PageLogID, "Submit Button", 1, "Mailig Process Started", "Normal");
                    AppUtility.SendRegistrationMail(licvm);
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
            finally
            {
                RegistrationGrid.IsEnabled = true;
            }
        }





        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            AppUtility.UpdatePageLogger(PageLogID);
        }

        private void CheckBoxZone_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chkService = (CheckBox)sender;
            Int64 ServiceID = (Int64)chkService.Tag;
            SearchTypeList.Where(w => w.ServiceID == ServiceID).First().IsRequired = true;
        }

        private void CheckBoxZone_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chkService = (CheckBox)sender;
            Int64 ServiceID = (Int64)chkService.Tag;
            SearchTypeList.Where(w => w.ServiceID == ServiceID).First().IsRequired = false;
        }

        private void btnActivate_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
