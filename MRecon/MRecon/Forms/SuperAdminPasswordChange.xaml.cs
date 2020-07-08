using MRecon.Database;
using MRecon.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for SuperAdminPasswordChange.xaml
    /// </summary>
    public partial class SuperAdminPasswordChange : Page
    {
        Int64 PageLogID;
        public SuperAdminPasswordChange()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Page Event Logger
                AppUtility.PageEventLogger(PageLogID, "Submit", 1, "User Name and Password Setup", "Normal");
                DbModel db = new DbModel();
                UserMaster user = db.UserMasters.Where(w => w.RoleID == 1).FirstOrDefault();
                user.UserName = txtUserID.Text;
                user.Password = txtPassword.Password;
                user.ConfirmPassword = txtConfirmPassword.Password;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                // Page Event Logger
                AppUtility.PageEventLogger(PageLogID, "Submit", 1, "User Name and Password Setup Done", "Normal");
                MessageBox.Show("User Successfully created. Please remember your credentials for future.");
                Frame MainFrame = AppUtility.FindChild<Frame>(Application.Current.MainWindow, "MainFrame");
                MainFrame.Navigate(new System.Uri("Forms/EmailConfiguration.xaml", UriKind.RelativeOrAbsolute));                
            }
            catch (Exception ex)
            {
                // Page Event Logger
                AppUtility.PageEventLogger(PageLogID, "Submit", 1, ex.StackTrace, "Error");
                MessageBox.Show("Their is some issue please login with mobileno as user name and password.");
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Page Logger
            PageLogID = AppUtility.PageLogger(9, 1);
            // Page Event Logger
            AppUtility.PageEventLogger(PageLogID, "Page_Loaded", 1, "Form Load", "Normal");
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            AppUtility.PageEventLogger(PageLogID, "Page_Unloaded", 1, "Form UnLoad", "Normal");
            AppUtility.UpdatePageLogger(PageLogID);
        }
    }
}
