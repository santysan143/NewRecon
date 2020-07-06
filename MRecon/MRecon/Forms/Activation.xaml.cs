using MRecon.Database;
using MRecon.Model;
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
                string[] infos = Value.Split('|');
                string SystemName = infos[9];
                string MacAddress = infos[8];
                string MobileNo = infos[5];
                string EmailID = infos[6];
                string Name = infos[4];
                string _Key = infos[7];
                string ActivationKey = infos[1];
                if (infos.Count() == 10)
                {
                    var _ExistReg = db.RegistrationMasters.Where(w => w.SystemName == SystemName && w.MacAddress == MacAddress && w.MobileNo == MobileNo && w.EmailID == EmailID && w.Name == Name && w.Key == _Key).FirstOrDefault();
                    if (_ExistReg != null)
                    {
                        if (Convert.ToBoolean(infos[0]))
                        {
                            _ExistReg.ActivationKey = ActivationKey;
                            // Page Event Logger
                            AppUtility.PageEventLogger(PageLogID, "Activation Button", 1, "Product Activated", "Normal");
                            MessageBox.Show("Your product has been activated till " + infos[1]);
                            AppUtility.AdminUserCreateAndRoleMapping(_ExistReg);
                            // Page Event Logger
                            AppUtility.PageEventLogger(PageLogID, "Activation Button", 1, "Moved To Super Admin Password Change", "Normal");
                            Frame MainFrame = AppUtility.FindChild<Frame>(Application.Current.MainWindow, "MainFrame");
                            MainFrame.Navigate(new System.Uri("Forms/SuperAdminPasswordChange.xaml", UriKind.RelativeOrAbsolute));
                        }
                        else
                        {
                            // Page Event Logger
                            AppUtility.PageEventLogger(PageLogID, "Activation Button", 1, "Mail Process Triggerred Again", "Normal");
                            MessageBox.Show("Your product has not been activated. Please send mail again");
                            AppUtility.SendRegistrationMail(_ExistReg);
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
