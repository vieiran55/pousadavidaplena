using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PousadaVidaPlena.Migrations
{
    /// <inheritdoc />
    public partial class Other2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Room");

            migrationBuilder.AddColumn<int>(
                name: "RoomNumber",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Room");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Room",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
