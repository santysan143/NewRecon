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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistrationMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("Forms/Registration.xaml",
                        UriKind.RelativeOrAbsolute));
        }

        private void ActivationMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("Forms/Activation.xaml",
                       UriKind.RelativeOrAbsolute));
        }

        private void CreateRoleSubMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("Forms/CreateRole.xaml",
                        UriKind.RelativeOrAbsolute));
        }

        private void RoleMappingSubMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("Forms/RoleMapping.xaml",
                                  UriKind.RelativeOrAbsolute));
        }

        private void CreateUserSubMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("Forms/CreateUser.xaml",
                                 UriKind.RelativeOrAbsolute));
        }

        private void UserMappingSubMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("Forms/UserMapping.xaml",
                                UriKind.RelativeOrAbsolute));
        }

        private void CreditCardSubMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("Forms/CreditCard.xaml",
                               UriKind.RelativeOrAbsolute));
        }

        private void MobileNoSubMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("Forms/MobileNo.xaml",
                             UriKind.RelativeOrAbsolute));
        }

        private void PanCardSubMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("Forms/PanCard.xaml",
                            UriKind.RelativeOrAbsolute));
        }

        private void AdhaarCardSubMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("Forms/AdhaarCard.xaml",
                           UriKind.RelativeOrAbsolute));
        }

        private void ReviewScanSubMenu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("Forms/ReviewScan.xaml",
                         UriKind.RelativeOrAbsolute));
        }
    }
}
