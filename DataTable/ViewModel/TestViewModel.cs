using DataTable.Models.db;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataTable.ViewModel
{
    public class TestViewModel
    {
        public int EmployeeId { get; set; } 
       
        public String Name { get; set; }
       
        public String Position { get; set; }
       
        public String Office { get; set; }
     
        public int? Age { get; set; }
        
        public decimal? Salary { get; set; }
  
        public String Sex { get; set; }

        public int GenderId { get; set; }
        public String NameGen { get; set; }
        public bool IsEnable { get; set; }


        public List<Gender> GenderList {get; set; }
        public List<SelectListItem> AgeList { get; set; }


        public DateTime dtmDate { get; set; }
    }
}
