using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSibers.Migrations
{
    public partial class LittleChangesinModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_StatusofTask_StatusofTaskStatusID",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_StatusofTaskStatusID",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "StatusofTaskStatusID",
                table: "Task");

            migrationBuilder.CreateIndex(
                name: "IX_Task_StatusID",
                table: "Task",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_StatusofTask_StatusID",
                table: "Task",
                column: "StatusID",
                principalTable: "StatusofTask",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_StatusofTask_StatusID",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_StatusID",
                table: "Task");

            migrationBuilder.AddColumn<int>(
                name: "StatusofTaskStatusID",
                table: "Task",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_StatusofTaskStatusID",
                table: "Task",
                column: "StatusofTaskStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_StatusofTask_StatusofTaskStatusID",
                table: "Task",
                column: "StatusofTaskStatusID",
                principalTable: "StatusofTask",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
