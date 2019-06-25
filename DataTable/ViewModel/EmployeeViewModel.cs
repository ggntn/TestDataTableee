﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataTable.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Office { get; set; }
        [Range(5, 65)]
        public int? Age { get; set; }
        [Required]
        public decimal? Salary { get; set; }
        [Required]
        public bool Sex { get; set; }
       
        
    }
}
