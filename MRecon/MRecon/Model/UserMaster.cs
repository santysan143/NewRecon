using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRecon.Model
{
    public class UserMaster
    {
        [Key]
        public Int64 UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }
        [Required]
        public Int64 RoleID { get; set; }
        [Required]
        public Int64 ClientID { get; set; }
        [Required]
        public Int64 ManagerID { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedDtTm { get; set; }
        public Int64? ModifiedBy { get; set; }
        public DateTime? ModifiedDtTm { get; set; }
    }
}
