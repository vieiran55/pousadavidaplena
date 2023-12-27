﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PousadaVidaPlena.Migrations
{
    /// <inheritdoc />
    public partial class reservation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RoomPrice",
                table: "Reservation",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomPrice",
                table: "Reservation");
        }
    }
}
