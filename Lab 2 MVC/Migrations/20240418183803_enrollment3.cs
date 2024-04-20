using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_2_MVC.Migrations
{
    /// <inheritdoc />
    public partial class enrollment3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EnrollmentId",
                table: "Teachers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EnrollmentId1",
                table: "Teachers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_EnrollmentId",
                table: "Teachers",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_EnrollmentId1",
                table: "Teachers",
                column: "EnrollmentId1");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Enrollments_EnrollmentId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Enrollments_EnrollmentId1",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_EnrollmentId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_EnrollmentId1",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "EnrollmentId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "EnrollmentId1",
                table: "Teachers");
        }
    }
}
