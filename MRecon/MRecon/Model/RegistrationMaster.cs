using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.Model
{
    public class RegistrationMaster
    {
        [Key]
        public Int64 RegistrationID { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string MacAddress { get; set; }
        public string SystemName { get; set; }
        public string Key { get; set; }
        public bool IsSentForRegistration { get; set; }
        public string ActivationKey { get; set; }
        public bool IsActivated { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedDtTm { get; set; }
        public Int64? ModifiedBy { get; set; }
        public DateTime? ModifiedDtTm { get; set; }
    }
}
