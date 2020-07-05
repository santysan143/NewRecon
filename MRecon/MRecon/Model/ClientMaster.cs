using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.Model
{
    public class ClientMaster
    {
///testing
        [Key]
        public Int64 ClientID { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string EmailID { get; set; }
        [Required]
        public string Address { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedDtTm { get; set; }
        public Int64? ModifiedBy { get; set; }
        public DateTime? ModifiedDtTm { get; set; }
    }
}
