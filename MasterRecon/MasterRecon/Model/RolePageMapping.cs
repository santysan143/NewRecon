﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterRecon.Model
{
    public class RolePageMapping
    {
        [Key]
        public Int64 RolePageID { get; set; }
        [Required]
        public Int64 PageID { get; set; }
        [Required]
        public Int64 RoleID { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime? CreatedDtTm { get; set; }
        public Int64? ModifiedBy { get; set; }
        public DateTime? ModifiedDtTm { get; set; }
    }
}
