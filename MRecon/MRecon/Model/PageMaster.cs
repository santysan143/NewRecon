using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.Model
{
    public class PageMaster
    {
        [Key]
        public Int64 PageID { get; set; }
        [Required]
        public string PageName { get; set; }
        public int PageType { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedDtTm { get; set; }
        public Int64? ModifiedBy { get; set; }
        public DateTime? ModifiedDtTm { get; set; }
    }
}
