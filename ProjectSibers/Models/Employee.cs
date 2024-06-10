using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSibers.Models
{
    public class Employee
    {
        [Key]//атрибут для Primary Key
        public int EmployeeID { get; set; }

        [Column(TypeName = "Varchar(25)")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Column(TypeName = "Varchar(25)")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Column(TypeName = "Varchar(25)")]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Column(TypeName = "Varchar(25)")]
        [EmailAddress]
        [Display(Name ="Почта")]
        public string Email { get; set; }
        [Display(Name = "Должность")]
        public int DoljnostID { get; set; }
          [Display(Name = "Должность")]
        public Doljnost Doljnost { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<Employee_Project> employee_Projects { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Task_Employee> task_Employees { get; set; }
        
    }
}
