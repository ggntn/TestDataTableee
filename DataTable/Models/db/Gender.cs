using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataTable.Models.db
{
    public class Gender
    {
        public int GenderId { get; set; }
        
        public string Name { get; set; }
       
        public bool IsEnable { get; set; }
    }
}
