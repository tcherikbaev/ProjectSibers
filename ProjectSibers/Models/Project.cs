using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSibers.Models
{
    public class Project
    {

        [Key]
        public int ProjectID { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Заказчик")]
        public string Customer { get; set; }
        [Display(Name = "Исполнитель")]
        public string Executor { get; set; }
        [Display(Name = "Руководитель")]
        public int EmployeeID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата начала")]
        public DateTime beginDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата окончания")]
        public DateTime finishDate { get; set; }
        [Display(Name = "Приоритет")]
        public int Priority { get; set; }
      
        public string EmployeeName;
        [Display(Name = "Руководитель")]
        public Employee Employee { get; set; }

        public ICollection<Employee_Project> employee_Projects { get; set; }
        public ICollection<Project_Task> Project_Tasks { get; set; }
    }
}
