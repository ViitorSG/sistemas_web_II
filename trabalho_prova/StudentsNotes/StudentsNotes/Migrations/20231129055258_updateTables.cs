using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsNotes.Migrations
{
    /// <inheritdoc />
    public partial class updateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Disciplines_DisciplineID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DisciplineID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DisciplineID",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasNotebook",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_grades_DisciplineID",
                table: "grades",
                column: "DisciplineID");

            migrationBuilder.CreateIndex(
                name: "IX_grades_StudentID",
                table: "grades",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentID",
                table: "Enrollments",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentID",
                table: "Enrollments",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_grades_Disciplines_DisciplineID",
                table: "grades",
                column: "DisciplineID",
                principalTable: "Disciplines",
                principalColumn: "DisciplineID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_grades_Students_StudentID",
                table: "grades",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_grades_Disciplines_DisciplineID",
                table: "grades");

            migrationBuilder.DropForeignKey(
                name: "FK_grades_Students_StudentID",
                table: "grades");

            migrationBuilder.DropIndex(
                name: "IX_grades_DisciplineID",
                table: "grades");

            migrationBuilder.DropIndex(
                name: "IX_grades_StudentID",
                table: "grades");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_StudentID",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "HasNotebook",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "DisciplineID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_DisciplineID",
                table: "Students",
                column: "DisciplineID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Disciplines_DisciplineID",
                table: "Students",
                column: "DisciplineID",
                principalTable: "Disciplines",
                principalColumn: "DisciplineID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
