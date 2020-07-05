using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.Model
{
    public class PageLogMaster
    {
        [Key]
        public Int64 LogID { get; set; }
        public Int64 UserID { get; set; }
        public Int64 PageID { get; set; }
        public DateTime PageEnteredDtTm { get; set; }
        public DateTime? PageLeftDtTm { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedDtTm { get; set; }
        public Int64? ModifiedBy { get; set; }
        public DateTime? ModifiedDtTm { get; set; }
    }
}
