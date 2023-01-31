using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiKnowlegde.Migrations
{
    /// <inheritdoc />
    public partial class keyetreprises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "enterprisesId",
                table: "departaments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "enterprisesId",
                table: "departaments",
                type: "integer",
                nullable: true);
        }
    }
}
