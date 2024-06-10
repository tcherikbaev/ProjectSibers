using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSibers.Migrations
{
    public partial class LittleChangeinModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Employee_Employees_EmployeeId",
                table: "Task_Employee");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Task_Employee",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Task_Employee_EmployeeId",
                table: "Task_Employee",
                newName: "IX_Task_Employee_EmployeeID");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Task",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "Task",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Employee_Employees_EmployeeID",
                table: "Task_Employee",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Employee_Employees_EmployeeID",
                table: "Task_Employee");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Task_Employee",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_Employee_EmployeeID",
                table: "Task_Employee",
                newName: "IX_Task_Employee_EmployeeId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Task",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Author",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Employee_Employees_EmployeeId",
                table: "Task_Employee",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
