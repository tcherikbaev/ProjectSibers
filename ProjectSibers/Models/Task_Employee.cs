using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSibers.Models
{
    public class Task_Employee
    {
        [Key]
        public int Te_ID { get; set; }
        public int TaskID { get; set; }
        public int EmployeeID{ get; set; }
        [Display(Name = "Задача")]
        public Task Task { get; set; }
        [Display(Name = "Сотрудник")]
        public Employee Employee { get; set; }
    }
}
