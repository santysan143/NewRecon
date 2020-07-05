using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.Model
{
    public class SearchDetailMaster
    {
        [Key]
        public Int64 SearchDetailID { get; set; }
        [Required]
        public string MacAddress { get; set; }
        [Required]
        public string DesktopName { get; set; }
        public string IPAddress { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedDtTm { get; set; }
        public Int64? ModifiedBy { get; set; }
        public DateTime? ModifiedDtTm { get; set; }
    }
}
