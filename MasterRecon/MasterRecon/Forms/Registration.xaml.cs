using MasterRecon.Database;
using MasterRecon.Model;
using MasterRecon.ViewModel;
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
        List<Service> SearchTypeList;
        LicenseViewModel licvm;
        public Registration()
        {
            InitializeComponent();
        }

        private void btnValidate_Click(object sender, RoutedEventArgs e)
        {
            txtActivationKey.SelectAll();
            string value = Utility.Utility.Decrypt(txtActivationKey.Selection.Text);
            licvm = Newtonsoft.Json.JsonConvert.DeserializeObject<LicenseViewModel>(value);
            var _ExistReg = db.RegistrationMasters.Where(w => w.Key == licvm.Key && w.SystemName == licvm.SystemName && w.MacAddress == licvm.MacAddress && w.MobileNo == licvm.MobileNo && w.EmailID == licvm.EmailID && w.Name == licvm.Name).FirstOrDefault();
            if (_ExistReg != null)
            {
                if (_ExistReg.IsActivated)
                {
                    licvm.ServiceList = new List<Service>();
                    licvm.ServiceList.AddRange(db.RegistrationWiseSearchTypes.Join(db.SearchTypeMasters, x => x.SearchTypeID, y => y.SearchTypeID, (x, y) => new { x, y.SearchName }).Where(w => w.x.RegistrationID == _ExistReg.RegistrationID).Select(s => new Service() { ServiceID = s.x.SearchTypeID, IsRequired = s.x.IsRequired, IsActivated = s.x.IsActivated, ServiceName = s.SearchName }).ToList());
                    licvm.IsActivated = _ExistReg.IsActivated;
                    licvm.ActivationDtTm = _ExistReg.ActivatedDtTm;
                    licvm.ActivationKey = _ExistReg.ActivationKey;
                    licvm.ActivationUptoDtTm = _ExistReg.ActivatedTillDtTm;
                    MessageBox.Show("Same key has been already activated.");
                    MailData(licvm, _ExistReg.RegistrationID);
                }
            }
            else
            {
                if (licvm != null)
                {
                    listBoxSeachType.ItemsSource = licvm.ServiceList;
                    txtFullName.Text = licvm.Name;
                    txtMobileNo.Text = licvm.MobileNo;
                    txtEmailID.Text = licvm.EmailID;
                    txtCompany.Text = licvm.CompanyName;
                    txtLicenseCount.Text = Convert.ToString(licvm.SystemCount);
                    txtActivationKey.IsEnabled = false;
                    btnValidate.IsEnabled = false;
                    _Reg = new RegistrationMaster();
                    _Reg.Name = licvm.Name;
                    _Reg.MobileNo = licvm.MobileNo;
                    _Reg.EmailID = licvm.EmailID;
                    _Reg.Key = licvm.Key;
                    _Reg.MacAddress = licvm.MacAddress;
                    _Reg.SystemName = licvm.SystemName;
                    _Reg.CompanyName = licvm.CompanyName;
                    _Reg.LicenseCount = licvm.SystemCount;
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
            _Reg.CompanyName = licvm.CompanyName;
            _Reg.LicenseCount = licvm.SystemCount;
            db.RegistrationMasters.Add(_Reg);
            db.SaveChanges();
            licvm.ActivationKey = _Reg.ActivationKey;
            licvm.ActivationDtTm = _Reg.ActivatedDtTm;
            licvm.ActivationUptoDtTm = _Reg.ActivatedTillDtTm;
            licvm.IsActivated = _Reg.IsActivated;
            foreach (var item in licvm.ServiceList)
            {
                RegistrationWiseSearchTypes reg = new RegistrationWiseSearchTypes();
                reg.CreatedBy = 1;
                reg.CreatedDtTm = DateTime.Now;
                reg.IsActive = true;
                reg.IsActivated = (item.IsRequired == true) ? true : false;
                reg.RegistrationID = _Reg.RegistrationID;
                reg.IsRequired = item.IsRequired;
                reg.SearchTypeID = item.ServiceID;
                db.RegistrationWiseSearchTypes.Add(reg);
                db.SaveChanges();
                item.IsActivated = (item.IsRequired == true) ? true : false;
            }
            MessageBox.Show("Registration has been done;");
            MailData(licvm, _Reg.RegistrationID);
            Frame MainFrame = AppUtility.FindChild<Frame>(Application.Current.MainWindow, "MainFrame");
            MainFrame.Navigate(new System.Uri("Forms/Home.xaml", UriKind.RelativeOrAbsolute));
        }

        private void MailData(LicenseViewModel _Reg, Int64 RegistrationID)
        {
            string Value = Utility.Utility.Encrypt(Newtonsoft.Json.JsonConvert.SerializeObject(_Reg));
            var curDir = Directory.GetCurrentDirectory();
            var curPath = curDir + "\\lic" + RegistrationID.ToString() + ".txt";
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
