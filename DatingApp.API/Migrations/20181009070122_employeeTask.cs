using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class employeeTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpNo = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpNo);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    No = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.No);
                });

            migrationBuilder.CreateTable(
                name: "AssignTasks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeEmpNo = table.Column<int>(nullable: false),
                    TaskNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignTasks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssignTasks_Employees_EmployeeEmpNo",
                        column: x => x.EmployeeEmpNo,
                        principalTable: "Employees",
                        principalColumn: "EmpNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignTasks_Tasks_TaskNo",
                        column: x => x.TaskNo,
                        principalTable: "Tasks",
                        principalColumn: "No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignTasks_EmployeeEmpNo",
                table: "AssignTasks",
                column: "EmployeeEmpNo");

            migrationBuilder.CreateIndex(
                name: "IX_AssignTasks_TaskNo",
                table: "AssignTasks",
                column: "TaskNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignTasks");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
