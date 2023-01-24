using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApiKnowlegde.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<string>(name: "modified_by", type: "text", nullable: false),
                    modifieddate = table.Column<DateTime>(name: "modified_date", type: "timestamp with time zone", nullable: true),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    position = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "entrerprises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<string>(name: "modified_by", type: "text", nullable: false),
                    modifieddate = table.Column<DateTime>(name: "modified_date", type: "timestamp with time zone", nullable: true),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrerprises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "departaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    createdby = table.Column<string>(name: "created_by", type: "text", nullable: false),
                    createddate = table.Column<DateTime>(name: "created_date", type: "timestamp with time zone", nullable: true),
                    modifiedby = table.Column<string>(name: "modified_by", type: "text", nullable: false),
                    modifieddate = table.Column<DateTime>(name: "modified_date", type: "timestamp with time zone", nullable: true),
                    status = table.Column<bool>(type: "boolean", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    enterprisesId = table.Column<int>(type: "integer", nullable: false),
                    entrerprisesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departaments_entrerprises_entrerprisesId",
                        column: x => x.entrerprisesId,
                        principalTable: "entrerprises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departaments_entrerprisesId",
                table: "departaments",
                column: "entrerprisesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departaments");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "entrerprises");
        }
    }
}
