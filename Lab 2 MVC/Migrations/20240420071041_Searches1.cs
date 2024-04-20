using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_2_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Searches1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FKStudent",
                table: "Searches");

            migrationBuilder.DropColumn(
                name: "FKTeacher",
                table: "Searches");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FKStudent",
                table: "Searches",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FKTeacher",
                table: "Searches",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
