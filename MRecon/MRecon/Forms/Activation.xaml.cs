using MRecon.Database;
using MRecon.Model;
using MRecon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace MRecon.Forms
{
    /// <summary>
    /// Interaction logic for Activation.xaml
    /// </summary>
    public partial class Activation : Page
    {
        DbModel db = new DbModel();
        Int64 PageLogID;
        public Activation()
        {
            InitializeComponent();
        }

        private void btnActivate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Page Event Logger
                AppUtility.PageEventLogger(PageLogID, "Activation Button", 1, "Activation Button Click", "Normal");
                txtActivationKey.SelectAll();
                string Value = Utility.Utility.Decrypt(txtActivationKey.Selection.Text);
                LicenseViewModel licvm = Newtonsoft.Json.JsonConvert.DeserializeObject<LicenseViewModel>(Value);

                if (licvm != null)
                {
                    var _ExistReg = db.RegistrationMasters.Where(w => w.Key == licvm.Key && w.IsActive == true).FirstOrDefault();
                    if (_ExistReg != null)
                    {
                        if (Convert.ToBoolean(licvm.IsActivated) && licvm.SystemName == System.Net.Dns.GetHostName())
                        {
                            _ExistReg.ActivationKey = licvm.ActivationKey;
                            // Page Event Logger
                            AppUtility.PageEventLogger(PageLogID, "Activation Button", 1, "Product Activated", "Normal");
                            MessageBox.Show("Your product has been activated till " + licvm.ActivationUptoDtTm);
                            AppUtility.AdminUserCreateAndRoleMapping(_ExistReg, licvm);
                            // Page Event Logger
                            AppUtility.PageEventLogger(PageLogID, "Activation Button", 1, "Moved To Super Admin Password Change", "Normal");
                            Frame MainFrame = AppUtility.FindChild<Frame>(Application.Current.MainWindow, "MainFrame");
                            MainFrame.Navigate(new System.Uri("Forms/SuperAdminPasswordChange.xaml", UriKind.RelativeOrAbsolute));
                        }
                        else if (Convert.ToBoolean(licvm.IsActivated) && (_ExistReg.LicenseCount - _ExistReg.LicenseUsed) > 0)
                        {
                            AppUtility.PageEventLogger(PageLogID, "Activation Button", 1, "Register Other Systems", "Normal");
                            bool IsRegisterd = AppUtility.AdditionSystemRegistration(_ExistReg, licvm);
                            if (IsRegisterd)
                            {
                                MessageBox.Show("This device is registered successfully");
                                LoginWindow frm = new LoginWindow();
                                this.Cursor = Cursors.Arrow;
                                frm.Show();
                                Application.Current.MainWindow.Close();
                            }
                            else
                            {
                                MessageBox.Show("Please contact the administrator.");
                            }
                        }
                        else
                        {
                            // Page Event Logger
                            AppUtility.PageEventLogger(PageLogID, "Activation Button", 1, "Mail Process Triggerred Again", "Normal");
                            MessageBox.Show("Your product has not been activated. Please send mail again");


                            LicenseViewModel licvmn = new LicenseViewModel();
                            licvmn.ServiceList = new List<Service>();
                            licvmn.ServiceList.AddRange(db.RegistrationWiseSearchTypes.Join(db.SearchTypeMasters, x => x.SearchTypeID, y => y.SearchTypeID, (x, y) => new { x, y.SearchName }).Where(w => w.x.RegistrationID == _ExistReg.RegistrationID).Select(s => new Service() { ServiceID = s.x.SearchTypeID, IsRequired = s.x.IsRequired, IsActivated = false }).ToList());
                            licvmn.CompanyName = _ExistReg.CompanyName;
                            licvmn.EmailID = _ExistReg.EmailID;
                            licvmn.Key = _ExistReg.Key;
                            licvmn.MacAddress = _ExistReg.MacAddress;
                            licvmn.MobileNo = _ExistReg.MobileNo;
                            licvmn.Name = _ExistReg.MobileNo;
                            licvmn.SystemCount = _ExistReg.LicenseCount;
                            licvmn.SystemName = _ExistReg.SystemName;
                            AppUtility.SendRegistrationMail(licvmn);
                        }
                    }
                }
                else
                {
                    // Page Event Logger
                    AppUtility.PageEventLogger(PageLogID, "Activation Button", 1, "Invalid Activation Key", "Normal");
                    MessageBox.Show("Registration key is not valid. Please Try Again");
                }
            }
            catch (Exception ex)
            {
                // Page Event Logger
                AppUtility.PageEventLogger(PageLogID, "Activation Button", 1, ex.StackTrace, "Error");
                MessageBox.Show("Registration key is not valid. Please Try Again");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Page Logger
            PageLogID = AppUtility.PageLogger(2, 1);
            // Page Event Logger
            AppUtility.PageEventLogger(PageLogID, "Constructor", 1, "Form Load", "Normal");
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            AppUtility.UpdatePageLogger(PageLogID);
        }
    }
}
