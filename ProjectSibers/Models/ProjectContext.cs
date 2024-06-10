using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectSibers.Models;

namespace ProjectSibers.Models
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }
   
        //Добавление таблиц в наш DBContext
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Doljnost> Doljnosts { get; set; }
        public DbSet<Employee_Project> employee_Projects { get; set; }

        //метод для возможному предотвращению к появлению циклов или множественных каскадных путей.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

        }

        //метод для возможному предотвращению к появлению циклов или множественных каскадных путей.
        public DbSet<ProjectSibers.Models.Task> Task { get; set; }

        //метод для возможному предотвращению к появлению циклов или множественных каскадных путей.
        public DbSet<ProjectSibers.Models.Status> StatusofTask { get; set; }

        //метод для возможному предотвращению к появлению циклов или множественных каскадных путей.
        public DbSet<ProjectSibers.Models.Project_Task> Project_Task { get; set; }

        //метод для возможному предотвращению к появлению циклов или множественных каскадных путей.
        public DbSet<ProjectSibers.Models.Task_Employee> Task_Employee { get; set; }
    }
}
