using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagement.Migrations
{
    public partial class CascadeforClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Classes__CourseI__2B3F6F97",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK__Classes__MajorId__2A4B4B5E",
                table: "Classes");

            migrationBuilder.AddForeignKey(
                name: "FK__Classes__CourseI__2B3F6F97",
                table: "Classes",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Classes__MajorId__2A4B4B5E",
                table: "Classes",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "MajorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Classes__CourseI__2B3F6F97",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK__Classes__MajorId__2A4B4B5E",
                table: "Classes");

            migrationBuilder.AddForeignKey(
                name: "FK__Classes__CourseI__2B3F6F97",
                table: "Classes",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Classes__MajorId__2A4B4B5E",
                table: "Classes",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "MajorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
