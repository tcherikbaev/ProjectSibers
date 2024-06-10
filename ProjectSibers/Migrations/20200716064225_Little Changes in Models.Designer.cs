﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectSibers.Models;

namespace ProjectSibers.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20200716064225_Little Changes in Models")]
    partial class LittleChangesinModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectSibers.Models.Doljnost", b =>
                {
                    b.Property<int>("DoljnostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("Varchar(25)");

                    b.HasKey("DoljnostID");

                    b.ToTable("Doljnosts");
                });

            modelBuilder.Entity("ProjectSibers.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DoljnostID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("Varchar(25)");

                    b.Property<string>("Name")
                        .HasColumnType("Varchar(25)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("Varchar(25)");

                    b.Property<string>("Surname")
                        .HasColumnType("Varchar(25)");

                    b.HasKey("EmployeeID");

                    b.HasIndex("DoljnostID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ProjectSibers.Models.Employee_Project", b =>
                {
                    b.Property<int>("epID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.HasKey("epID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ProjectID");

                    b.ToTable("employee_Projects");
                });

            modelBuilder.Entity("ProjectSibers.Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Customer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Executor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<DateTime>("beginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("finishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectSibers.Models.Project_Task", b =>
                {
                    b.Property<int>("Pt_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<int>("TaskID")
                        .HasColumnType("int");

                    b.HasKey("Pt_ID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("TaskID");

                    b.ToTable("Project_Task");
                });

            modelBuilder.Entity("ProjectSibers.Models.Status", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusID");

                    b.ToTable("StatusofTask");
                });

            modelBuilder.Entity("ProjectSibers.Models.Task", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.HasKey("TaskID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("StatusID");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("ProjectSibers.Models.Task_Employee", b =>
                {
                    b.Property<int>("Te_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("TaskID")
                        .HasColumnType("int");

                    b.HasKey("Te_ID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("TaskID");

                    b.ToTable("Task_Employee");
                });

            modelBuilder.Entity("ProjectSibers.Models.Employee", b =>
                {
                    b.HasOne("ProjectSibers.Models.Doljnost", "Doljnost")
                        .WithMany("Employees")
                        .HasForeignKey("DoljnostID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectSibers.Models.Employee_Project", b =>
                {
                    b.HasOne("ProjectSibers.Models.Employee", "Employee")
                        .WithMany("employee_Projects")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectSibers.Models.Project", "Project")
                        .WithMany("employee_Projects")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectSibers.Models.Project", b =>
                {
                    b.HasOne("ProjectSibers.Models.Employee", "Employee")
                        .WithMany("Projects")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectSibers.Models.Project_Task", b =>
                {
                    b.HasOne("ProjectSibers.Models.Project", "Project")
                        .WithMany("Project_Tasks")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectSibers.Models.Task", "Task")
                        .WithMany("Project_Tasks")
                        .HasForeignKey("TaskID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectSibers.Models.Task", b =>
                {
                    b.HasOne("ProjectSibers.Models.Employee", "Employee")
                        .WithMany("Tasks")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectSibers.Models.Status", "Status")
                        .WithMany("Tasks")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectSibers.Models.Task_Employee", b =>
                {
                    b.HasOne("ProjectSibers.Models.Employee", "Employee")
                        .WithMany("task_Employees")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProjectSibers.Models.Task", "Task")
                        .WithMany("task_Employees")
                        .HasForeignKey("TaskID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
