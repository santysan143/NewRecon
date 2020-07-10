using MRecon.Database;
using MRecon.Forms;
using MRecon.AbstractFactory;
using MRecon.Model;
using MRecon.SQLConnectionFactory;
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
using System.Configuration;

namespace MRecon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string ConnectionType = ConfigurationManager.AppSettings.Get("ConnectionType");
        public static IAbstractFactory _FactoryConnection;
        Int64 PageLogID;
        public MainWindow()
        {
            InitializeComponent();
            if (ConnectionType == "SQL")
                _FactoryConnection = new SQLConcreteFactory();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            //Page Logger
            PageLogID = AppUtility.PageLogger(0, 1);
            // Page Event Logger
            AppUtility.PageEventLogger(PageLogID, "Constructor", 1, "Form Load", "Normal");

            string SystemName = System.Net.Dns.GetHostName();
            string MacAddress = AppUtility.GetMachineData("MACAddress");
            //Initiliazing Frame
            var items = _FactoryConnection.Registration().GetRegistraionDetails();
            int _licensecount = 0;
            foreach (var dd in items)
            {
                if (dd.IsActivated == true && dd.IsSentForRegistration == true && dd.IsActive == true && DateTime.Now.AddDays(-1) < dd.ActivatedTillDtTm)
                {
                    _licensecount = 1;
                    var _ExistReg = _FactoryConnection.LicenseKeys().GetLicenseDetail(dd.RegistrationID, SystemName).ToList();

                    foreach (var item in _ExistReg)
                    {
                        AppUtility.PageEventLogger(PageLogID, "Constructor", 1, "Sent To Login Page", "Normal");
                        LoginWindow frm = new LoginWindow();
                        this.Cursor = Cursors.Arrow;
                        frm.Show();
                        this.Close();
                        break;
                    }
                    // Page Event Logger                   
                }
                else if (dd.IsActivated == true && DateTime.Now.AddDays(-1) > dd.ActivatedTillDtTm)
                {
                    _licensecount = 0;
                    //License Deativation
                    bool done = _FactoryConnection.Registration().LicenseDeactivation(dd);

                }
                if (_licensecount == 0)
                {
                    var _Licenses = _FactoryConnection.Registration().GetALLRegistraionDetails().OrderByDescending(o => o.ActivatedTillDtTm).ToList();
                    foreach (var item in _Licenses)
                    {
                        MessageBox.Show("Your license has been exipred on " + item.ActivatedTillDtTm + ". Please register again.");
                        break;
                    }
                }
            }
            if (_licensecount == 0)
            {
                var _Licenses = _FactoryConnection.Registration().GetALLRegistraionDetails().OrderByDescending(o => o.ActivatedTillDtTm).ToList();
                foreach (var item in _Licenses)
                {
                    MessageBox.Show("Your license has been exipred on " + item.ActivatedTillDtTm + ". Please register again.");
                    break;
                }
            }
            this.Cursor = Cursors.Arrow;
        }
    }
}
