using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiKnowlegde.Migrations
{
    /// <inheritdoc />
    public partial class DepartamentsEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departaments_employees",
                columns: table => new
                {
                    departamentsId = table.Column<int>(type: "integer", nullable: false),
                    employeesId = table.Column<int>(type: "integer", nullable: false),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<string>(name: "modified_by", type: "text", nullable: false),
                    modifieddate = table.Column<DateTime>(name: "modified_date", type: "timestamp with time zone", nullable: true),
                    status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departaments_employees", x => new { x.departamentsId, x.employeesId });
                    table.ForeignKey(
                        name: "FK_departaments_employees_departaments_departamentsId",
                        column: x => x.departamentsId,
                        principalTable: "departaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_departaments_employees_employees_employeesId",
                        column: x => x.employeesId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departaments_employees_employeesId",
                table: "departaments_employees",
                column: "employeesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departaments_employees");
        }
    }
}
