using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSibers.Models
{
    public class Doljnost
    {
        [Key]
        public int DoljnostID { get; set; }
        [Display(Name = "Наименование")]
        [Column(TypeName = "Varchar(25)")]
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
