using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSibers.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doljnosts",
                columns: table => new
                {
                    DoljnostID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doljnosts", x => x.DoljnostID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(25)", nullable: true),
                    Surname = table.Column<string>(type: "Varchar(25)", nullable: true),
                    Patronymic = table.Column<string>(type: "Varchar(25)", nullable: true),
                    Email = table.Column<string>(type: "Varchar(25)", nullable: true),
                    DoljnostID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Doljnosts_DoljnostID",
                        column: x => x.DoljnostID,
                        principalTable: "Doljnosts",
                        principalColumn: "DoljnostID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Customer = table.Column<string>(nullable: true),
                    Executor = table.Column<string>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: false),
                    beginDate = table.Column<DateTime>(nullable: false),
                    finishDate = table.Column<DateTime>(nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Projects_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employee_Projects",
                columns: table => new
                {
                    epID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee_Projects", x => x.epID);
                    table.ForeignKey(
                        name: "FK_employee_Projects_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employee_Projects_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_Projects_EmployeeID",
                table: "employee_Projects",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_employee_Projects_ProjectID",
                table: "employee_Projects",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DoljnostID",
                table: "Employees",
                column: "DoljnostID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EmployeeID",
                table: "Projects",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee_Projects");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Doljnosts");
        }
    }
}
