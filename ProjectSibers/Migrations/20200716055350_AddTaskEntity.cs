using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSibers.Migrations
{
    public partial class AddTaskEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusofTask",
                columns: table => new
                {
                    StatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusofTask", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Author = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    StatusofTaskStatusID = table.Column<int>(nullable: true),
                    EmployeeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_Task_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_StatusofTask_StatusofTaskStatusID",
                        column: x => x.StatusofTaskStatusID,
                        principalTable: "StatusofTask",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project_Task",
                columns: table => new
                {
                    Pt_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(nullable: false),
                    TaskID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Task", x => x.Pt_ID);
                    table.ForeignKey(
                        name: "FK_Project_Task_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Task_Task_TaskID",
                        column: x => x.TaskID,
                        principalTable: "Task",
                        principalColumn: "TaskID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Task_Employee",
                columns: table => new
                {
                    Te_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskID = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task_Employee", x => x.Te_ID);
                    table.ForeignKey(
                        name: "FK_Task_Employee_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_Employee_Task_TaskID",
                        column: x => x.TaskID,
                        principalTable: "Task",
                        principalColumn: "TaskID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_Task_ProjectID",
                table: "Project_Task",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Task_TaskID",
                table: "Project_Task",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_EmployeeID",
                table: "Task",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_StatusofTaskStatusID",
                table: "Task",
                column: "StatusofTaskStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Employee_EmployeeId",
                table: "Task_Employee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Employee_TaskID",
                table: "Task_Employee",
                column: "TaskID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project_Task");

            migrationBuilder.DropTable(
                name: "Task_Employee");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "StatusofTask");
        }
    }
}
