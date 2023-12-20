using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PousadaVidaPlena.Migrations
{
    /// <inheritdoc />
    public partial class ClientAtt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Client",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Cpf",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Client",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Client",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Rg",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "Client");
        }
    }
}
