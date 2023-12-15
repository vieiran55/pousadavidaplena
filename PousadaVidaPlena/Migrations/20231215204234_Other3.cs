using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PousadaVidaPlena.Migrations
{
    /// <inheritdoc />
    public partial class Other3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Room");
        }
    }
}
