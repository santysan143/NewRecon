using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.Model
{
    public class LicenseGenerationMaster
    {
        [Key]
        public Int64 LicenseGenerationID { get; set; }
        [Required]
        public Int64 ClientID { get; set; }
        [Required]
        public int LicencseCount { get; set; }
        [Required]
        public int LicenseType { get; set; }
        public int LicenseDuration { get; set; }
        public DateTime LicenseFromDtTm { get; set; }
        public DateTime LicenseToDtTm { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedDtTm { get; set; }
        public Int64? ModifiedBy { get; set; }
        public DateTime? ModifiedDtTm { get; set; }
    }
}
