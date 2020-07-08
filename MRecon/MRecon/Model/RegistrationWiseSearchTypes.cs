using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.Model
{
    public class RegistrationWiseSearchTypes
    {
        [Key]
        public Int64 RegistrationWiseSearchTypeID { get; set; }
        public Int64 RegistrationID { get; set; }
        public Int64 SearchTypeID { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsActivated { get; set; }
        public DateTime? ActivatedDtTm { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedDtTm { get; set; }
        public Int64? ModifiedBy { get; set; }
        public DateTime? ModifiedDtTm { get; set; }
    }
}
