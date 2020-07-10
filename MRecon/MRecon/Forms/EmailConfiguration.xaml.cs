using MRecon.Database;
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
    /// Interaction logic for EmailConfiguration.xaml
    /// </summary>
    public partial class EmailConfiguration : Page
    {
        DbModel db = new DbModel();
        public EmailConfiguration()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            MRecon.Model.EmailConfigurationMaster emailConfig = new MRecon.Model.EmailConfigurationMaster();
            emailConfig.CreatedBy = 1;
            emailConfig.CreatedDtTm = DateTime.Now;
            emailConfig.EmailID = txtEmailID.Text;
            emailConfig.IsActive = true;
            emailConfig.IsSSLRequired = (chkSLL.IsChecked == true) ? true : false;
            emailConfig.Password = txtEmailPassword.Password;
            emailConfig.Port = Convert.ToInt32(txtPortNnumber.Text);
            emailConfig.ServerName = txtServer.Text;
            db.EmailConfigurationMasters.Add(emailConfig);
            db.SaveChanges();
            if (emailConfig.EmailConfigurationID > 0)
            {
                LoginWindow login = new LoginWindow();
                login.Show();
                Application.Current.MainWindow.Close();
            }
        }

        private void btnSkip_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            Application.Current.MainWindow.Close();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].Height = this.Height;
        }
    }
}
