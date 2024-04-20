using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_2_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Searches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Enrollments_EnrollmentId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Enrollments_EnrollmentId1",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "EnrollmentId1",
                table: "Teachers",
                newName: "SearchId1");

            migrationBuilder.RenameColumn(
                name: "EnrollmentId",
                table: "Teachers",
                newName: "SearchId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_EnrollmentId1",
                table: "Teachers",
                newName: "IX_Teachers_SearchId1");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_EnrollmentId",
                table: "Teachers",
                newName: "IX_Teachers_SearchId");

            migrationBuilder.CreateTable(
                name: "Searches",
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
                    table.PrimaryKey("PK_Searches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Searches_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Searches_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Searches_StudentsId",
                table: "Searches",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Searches_TeachersId",
                table: "Searches",
                column: "TeachersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Searches_SearchId",
                table: "Teachers",
                column: "SearchId",
                principalTable: "Searches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Searches_SearchId1",
                table: "Teachers",
                column: "SearchId1",
                principalTable: "Searches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Searches_SearchId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Searches_SearchId1",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Searches");

            migrationBuilder.RenameColumn(
                name: "SearchId1",
                table: "Teachers",
                newName: "EnrollmentId1");

            migrationBuilder.RenameColumn(
                name: "SearchId",
                table: "Teachers",
                newName: "EnrollmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_SearchId1",
                table: "Teachers",
                newName: "IX_Teachers_EnrollmentId1");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_SearchId",
                table: "Teachers",
                newName: "IX_Teachers_EnrollmentId");

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TeachersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FKStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FKTeacher = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Enrollments_EnrollmentId",
                table: "Teachers",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Enrollments_EnrollmentId1",
                table: "Teachers",
                column: "EnrollmentId1",
                principalTable: "Enrollments",
                principalColumn: "Id");
        }
    }
}
