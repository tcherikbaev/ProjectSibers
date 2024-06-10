using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSibers.Models
{
    public class Project_Task
    {
        [Key]
        public int Pt_ID { get; set; }
        public int ProjectID { get; set; }
        public int TaskID { get; set; }
        [Display(Name = "Проект")]
        public Project Project { get; set; }
        [Display(Name = "Задача")]
        public Task Task { get; set; }
    }
}
