using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Department = table.Column<string>(type: "varchar(50)", nullable: false),
                    Position = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeadOfDepartmentApproval = table.Column<bool>(type: "bit", nullable: false),
                    OperationsApproval = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacationRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
         name: "Approvals",
         columns: table => new
         {
             Id = table.Column<int>(type: "int", nullable: false)
                 .Annotation("SqlServer:Identity", "1, 1"),
             VacationRequestId = table.Column<int>(type: "int", nullable: false),
             ApproverId = table.Column<int>(type: "int", nullable: false),
             ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
             Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
         },
         constraints: table =>
         {
             table.PrimaryKey("PK_Approvals", x => x.Id);
             table.ForeignKey(
                 name: "FK_Approvals_Employees_ApproverId",
                 column: x => x.ApproverId,
                 principalTable: "Employees",
                 principalColumn: "Id",
                 onDelete: ReferentialAction.Restrict); // add the "onDelete: ReferentialAction.Restrict" option here
             table.ForeignKey(
                 name: "FK_Approvals_VacationRequests_VacationRequestId",
                 column: x => x.VacationRequestId,
                 principalTable: "VacationRequests",
                 principalColumn: "Id",
                 onDelete: ReferentialAction.Cascade);
         });

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_ApproverId",
                table: "Approvals",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_VacationRequestId",
                table: "Approvals",
                column: "VacationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationRequests_EmployeeId",
                table: "VacationRequests",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approvals");

            migrationBuilder.DropTable(
                name: "VacationRequests");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
