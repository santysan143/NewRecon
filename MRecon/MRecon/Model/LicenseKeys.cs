using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.Model
{
    public class LicenseKeys
    {
        [Key]
        public Int64 LicenseKeyID { get; set; }
        [Required]
        public Int64 LicenseGenerationID { get; set; }
        [Required]
        public string LicenseKeyCode { get; set; }
        [Required]
        public int LicenseKeySequence { get; set; }
        public DateTime? RegistrationDtTm { get; set; }
        public DateTime? ValidUptoDtTm { get; set; }
        public string MacAddress { get; set; }
        public string DesktopName { get; set; }
        public string IpAddress { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedDtTm { get; set; }
        public Int64? ModifiedBy { get; set; }
        public DateTime? ModifiedDtTm { get; set; }
    }
}
