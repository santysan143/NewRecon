using MRecon.Database;
using MRecon.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.Mail;
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
using Utility;

namespace MRecon.Forms
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    /// 
    public partial class Registration : Page
    {
        DbModel db = new DbModel();
        public Registration()
        {
            InitializeComponent(); 
            string SystemName=System.Net.Dns.GetHostName();
            string MacAddress=GetMachineData("MACAddress");
            var dd = db.RegistrationMasters.Where(x => x.SystemName == SystemName && x.MacAddress == MacAddress).FirstOrDefault();
            if (dd != null)
            {
                SendRegistrationMail(dd);
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            RegistrationMaster _Reg = new RegistrationMaster();
            _Reg.CreatedBy = 1;
            _Reg.CreatedDtTm = DateTime.Now;
            _Reg.EmailID = txtEmailID.Text;
            _Reg.IsActive = true;
            _Reg.Key = Guid.NewGuid().ToString();
            _Reg.SystemName = System.Net.Dns.GetHostName();
            _Reg.MacAddress = GetMachineData("MACAddress");
            _Reg.Name = txtFullName.Text;
            _Reg.MobileNo = txtMobileNumber.Text;
            db.RegistrationMasters.Add(_Reg);
            db.SaveChanges();
            if (_Reg.RegistrationID > 0)
            {
                SendRegistrationMail(_Reg);
            }
        }

        private void SendRegistrationMail(RegistrationMaster _Reg)
        {
            string Value = Utility.Utility.Encrypt(_Reg.Name + "|" + _Reg.MobileNo + "|" + _Reg.EmailID + "|" + _Reg.Key + "|" + _Reg.MacAddress + "|" + _Reg.SystemName);
            var curDir = Directory.GetCurrentDirectory();
            var curPath = curDir + "\\lic.txt";
            var exsitpath = curPath.Replace(".txt",".rec");
            if (File.Exists(exsitpath))
            {
                File.Delete(exsitpath);
            }
            TextWriter txt = new StreamWriter(curPath);
            txt.Write(Value);
            txt.Close();
            File.Move(curPath, System.IO.Path.ChangeExtension(curPath, ".rec"));
            Process.Start("mailto:santysan143@gmail.com?Subject=hello&Attach=" + curDir );

        }

        public string GetMachineData(string Address)
        {
            ManagementClass MC = new ManagementClass("Win32_NetworkAdapter");
            ManagementObjectCollection MOCol = MC.GetInstances();
            string _address = "";
            foreach (ManagementObject MO in MOCol)
            {
                if (MO != null)
                {
                    if (MO[Address] != null)
                    {
                        _address = MO[Address].ToString();
                        if (_address != string.Empty)
                            break;
                    }
                }
            }
            return _address;


        }

    }
}
