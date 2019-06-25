using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataTable.Models.db
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="Enter Name")]
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
        public string Sex { get; set; }
        public int GenderId { get; set; }
        public DateTime Date { get; set; }
    }
}
