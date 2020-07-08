using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRecon.Database;

namespace MRecon.ViewModel
{
    public class LicenseViewModel
    {
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string CompanyName { get; set; }
        public int SystemCount { get; set; }
        public string SystemName { get; set; }
        public string MacAddress { get; set; }
        public string Key { get; set; }
        public string ActivationKey { get; set; }
        public bool? IsActivated { get; set; }
        public DateTime? ActivationDtTm { get; set; }
        public DateTime? ActivationUptoDtTm { get; set; }
        public List<Service> ServiceList { get; set; }
    }

    public class Service
    {
        public Int64 ServiceID { get; set; }
        public string ServiceName { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsActivated { get; set; }
    }
}
