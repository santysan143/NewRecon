using MasterRecon.Database;
using MasterRecon.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace MasterRecon.Forms
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        RegistrationMaster _Reg;
        DbModel db = new DbModel();
        public Registration()
        {
            InitializeComponent();
        }

        private void btnValidate_Click(object sender, RoutedEventArgs e)
        {

            string value = Utility.Utility.Decrypt(txtActivationKey.Text);
            string[] infos = value.Split('|');
            string SystemName = infos[5]; string MacAddress = infos[4]; string MobileNo = infos[1]; string EmailID = infos[2]; string Name = infos[0]; string _Key = infos[3];
            var _ExistReg = db.RegistrationMasters.Where(w => w.Key == _Key && w.SystemName == SystemName && w.MacAddress == MacAddress && w.MobileNo == MobileNo && w.EmailID == EmailID && w.Name == Name).FirstOrDefault();
            if (_ExistReg != null)
            {
                if (_ExistReg.IsActivated)
                {
                    MessageBox.Show("Same key has been already activated.");
                    MailData(_ExistReg);
                }
            }
            else
            {
                if (infos.Count() == 6)
                {
                    txtFullName.Text = Name;
                    txtMobileNo.Text = MobileNo;
                    txtEmailID.Text = EmailID;
                    lblFullName.Visibility = Visibility.Visible;
                    lblEmailID.Visibility = Visibility.Visible;
                    lblMobileName.Visibility = Visibility.Visible;
                    txtEmailID.Visibility = Visibility.Visible;
                    txtFullName.Visibility = Visibility.Visible;
                    txtMobileNo.Visibility = Visibility.Visible;
                    btnActivate.Visibility = Visibility.Visible;
                    txtValidUpto.Visibility = Visibility.Visible;
                    txtActivationKey.IsEnabled = false;
                    btnValidate.IsEnabled = false;
                    _Reg = new RegistrationMaster();
                    _Reg.Name = Name;
                    _Reg.MobileNo = MobileNo;
                    _Reg.EmailID = EmailID;
                    _Reg.Key = _Key;
                    _Reg.MacAddress = MacAddress;
                    _Reg.SystemName = SystemName;
                    _Reg.IsActive = true;
                    _Reg.CreatedBy = 1;
                    _Reg.CreatedDtTm = DateTime.Now;
                    _Reg.IsSentForRegistration = true;
                }
            }
        }

        private void btnActivate_Click(object sender, RoutedEventArgs e)
        {
            _Reg.ActivationKey = Guid.NewGuid().ToString();
            _Reg.ActivatedBy = "Test";
            _Reg.ActivatedDtTm = DateTime.Now;
            _Reg.ActivatedTillDtTm = txtValidUpto.SelectedDate;
            _Reg.IsActivated = true;
            db.RegistrationMasters.Add(_Reg);
            db.SaveChanges();
            MessageBox.Show("Registration has been done;");
            MailData(_Reg);
            Frame MainFrame = AppUtility.FindChild<Frame>(Application.Current.MainWindow, "MainFrame");
            MainFrame.Navigate(new System.Uri("Forms/Home.xaml", UriKind.RelativeOrAbsolute));
        }

        private void MailData(RegistrationMaster _Reg)
        {
            string Value = Utility.Utility.Encrypt(_Reg.IsActivated + "|" + _Reg.ActivationKey + "|" + _Reg.ActivatedDtTm + "|" + _Reg.ActivatedTillDtTm + "|" + _Reg.Name + "|" + _Reg.MobileNo + "|" + _Reg.EmailID + "|" + _Reg.Key + "|" + _Reg.MacAddress + "|" + _Reg.SystemName);
            var curDir = Directory.GetCurrentDirectory();
            var curPath = curDir + "\\lic" + _Reg.RegistrationID.ToString() + ".txt";
            var exsitpath = curPath.Replace(".txt", ".rec");
            //if (File.Exists(exsitpath))
            //{
            //    File.Delete(exsitpath);
            //}
            //TextWriter txt = new StreamWriter(curPath);
            //txt.Write(Value);
            //txt.Close();
            //// File Name Change
            //File.Move(curPath, System.IO.Path.ChangeExtension(curPath, ".rec"));
            //Mailing
            string mailto = string.Format("mailto:{0}?Subject={1}&Body={2}&Attachment={3}", _Reg.EmailID, "License Activated", "Please use this key for activation : " + Value + " .", exsitpath);
            Process.Start(mailto);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
