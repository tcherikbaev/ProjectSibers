using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ProjectSibers.Models
{
    public class Employee_Project
    {

        [Key]
        public int epID { get; set; }
   
        public int ProjectID { get; set; }
      
        public int EmployeeID { get; set; }
     [Display(Name = "Проект")]
        public Project Project { get; set; } 
        [Display(Name = "Сотрудник")]
        public Employee Employee { get; set; }
    }
}
