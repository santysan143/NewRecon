using MRecon.AbstractFactory;
using MRecon.Database;
using MRecon.SQLConnectionFactory;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Shapes;

namespace MRecon.Forms
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        static string ConnectionType = ConfigurationManager.AppSettings.Get("ConnectionType");
        public static IAbstractFactory _FactoryConnection;
        Int64 UserID;
        public LoginWindow()
        {
            InitializeComponent();
            if (ConnectionType == "SQL")
                _FactoryConnection = new SQLConcreteFactory();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            var LoginInfo =_FactoryConnection.UserMaster().GetUsers().Where(w => w.UserName == txtUserName.Text && w.Password == txtPassword.Password && w.IsActive == true).ToList();
            bool isLogin = false;
            
            foreach (var item in LoginInfo)
            {
                isLogin = true;
                UserID = item.UserID;
                break;
            }
            if (isLogin)
            {
                MessageBox.Show("Successfully logged in.");
                MasterWindow mainwindow = new MasterWindow(UserID);
                mainwindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please check your username and password.");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[1].Height = 200;
        }
    }
}
