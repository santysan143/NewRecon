using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.Model
{
    public class EmailConfigurationMaster
    {
        [Key]
        public Int64 EmailConfigurationID { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string ServerName { get; set; }
        public int Port { get; set; }
        public bool IsSSLRequired { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedDtTm { get; set; }
        public Int64? ModifiedBy { get; set; }
        public DateTime? ModifiedDtTm { get; set; }
    }
}
