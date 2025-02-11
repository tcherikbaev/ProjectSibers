﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSibers.Models
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public string Name { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
