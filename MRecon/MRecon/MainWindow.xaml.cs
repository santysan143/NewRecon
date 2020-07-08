using MRecon.Database;
using MRecon.Forms;
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

namespace MRecon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DbModel db = new DbModel();
        Int64 PageLogID;
        public MainWindow()
        {
            InitializeComponent();
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
            var items = db.RegistrationMasters.Where(x => x.IsActive == true).ToList();
            foreach (var dd in items)
            {
                if (dd.IsActivated == true && dd.IsSentForRegistration == true && dd.IsActive == true && DateTime.Now.AddDays(-1) < dd.ActivatedTillDtTm)
                {
                    var _ExistReg = db.LicenseKeys.Where(w => w.RegistrationID == dd.RegistrationID && w.DesktopName == SystemName).ToList();

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
                //else if (DateTime.Now.AddDays(-1) > dd.ActivatedTillDtTm)
                //{

                //}
            }
            this.Cursor = Cursors.Arrow;
        }



    }
}
