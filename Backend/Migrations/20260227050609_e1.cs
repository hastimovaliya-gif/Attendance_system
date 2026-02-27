using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace demoapplication.Migrations
{
    /// <inheritdoc />
    public partial class e1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinDailyHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.PolicyId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceRecords",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoursWorked = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceRecords", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_AttendanceRecords_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "PolicyId", "MinDailyHours", "Name" },
                values: new object[,]
                {
                    { 1, 8m, "Policy1 8 Hours" },
                    { 2, 7.5m, "Policy2 7.5 Hours" },
                    { 3, 9m, "Policy3 9 Hours" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FirstName", "IsActive", "LastName", "PolicyId" },
                values: new object[,]
                {
                    { 1, "ayush@mx.com", "Ayush", true, "Sarvaiya", 1 },
                    { 2, "hasti@mx.com", "Hasti", true, "Movaliya", 2 },
                    { 3, "hatim@mx.com", "Hatim", true, "Chharchhoda", 1 },
                    { 4, "srishti@mx.com", "Srishti", true, "Singh", 3 },
                    { 5, "veer@mx.com", "Veer", true, "Vora", 2 }
                });

            migrationBuilder.InsertData(
                table: "AttendanceRecords",
                columns: new[] { "AttendanceId", "AttendanceDate", "EmployeeId", "HoursWorked", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8.5m, "Present" },
                    { 2, new DateTime(2026, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6.5m, "ShortHours" },
                    { 3, new DateTime(2026, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0m, "Absent" },
                    { 4, new DateTime(2026, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 8m, "ShortHours" },
                    { 5, new DateTime(2026, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 7.5m, "Present" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecords_EmployeeId_AttendanceDate",
                table: "AttendanceRecords",
                columns: new[] { "EmployeeId", "AttendanceDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PolicyId",
                table: "Employees",
                column: "PolicyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceRecords");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Policies");
        }
    }
}
