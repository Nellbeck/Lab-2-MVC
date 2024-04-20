using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_2_MVC.Migrations
{
    /// <inheritdoc />
    public partial class enrollment2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FKTeacher = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FKStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TeachersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enrollments_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentsId",
                table: "Enrollments",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_TeachersId",
                table: "Enrollments",
                column: "TeachersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");
        }
    }
}
