using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace ProjectSibers.Models
{
    public class Task
    {
        [Key]
        public int TaskID { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        public int EmployeeID { get; set; }
     
        public int StatusID { get; set; }
        [Display(Name = "Комментарий")]
        public string Comments { get; set; }
        [Display(Name = "Приоритет")]
        public int Priority { get; set; }
           [Display(Name = "Автор")]
        public Employee Employee { get; set; }   
        [Display(Name = "Статус Задачи")]
        public Status Status { get; set; }
     
        public ICollection<Project_Task> Project_Tasks { get; set; }
        public ICollection<Task_Employee> task_Employees { get; set; }
    }
}
