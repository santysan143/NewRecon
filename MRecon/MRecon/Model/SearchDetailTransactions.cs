using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.Model
{
    public class SearchDetailTransactions
    {
        [Key]
        public Int64 TransactionID { get; set; }
        [Required]
        public Int64 SearchDetailID { get; set; }
        [Required]
        public Int64 SearchTypeID { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public Int64 FilePath { get; set; }
        [Required]
        public Int64 SearchText { get; set; }
        public Int64 LineNo { get; set; }
        [Required]
        public Int64 SearchStatusID { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedDtTm { get; set; }
        public Int64? ModifiedBy { get; set; }
        public DateTime? ModifiedDtTm { get; set; }
    }
}
