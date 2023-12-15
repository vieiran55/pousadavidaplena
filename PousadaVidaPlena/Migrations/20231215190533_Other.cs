using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PousadaVidaPlena.Migrations
{
    /// <inheritdoc />
    public partial class Other : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Room");
        }
    }
}
