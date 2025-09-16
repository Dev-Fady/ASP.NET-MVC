using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Q3DotNetAssiut.Migrations
{
    /// <inheritdoc />
    public partial class donedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    degree = table.Column<int>(type: "int", nullable: false),
                    minDegree = table.Column<int>(type: "int", nullable: false),
                    hours = table.Column<int>(type: "int", nullable: false),
                    dept_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_dept_id",
                        column: x => x.dept_id,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    grade = table.Column<int>(type: "int", nullable: false),
                    dept_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainees_Departments_dept_id",
                        column: x => x.dept_id,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dept_id = table.Column<int>(type: "int", nullable: false),
                    crs_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Courses_crs_id",
                        column: x => x.crs_id,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_dept_id",
                        column: x => x.dept_id,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CrsResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    degree = table.Column<int>(type: "int", nullable: false),
                    crs_id = table.Column<int>(type: "int", nullable: false),
                    trainee_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrsResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrsResults_Courses_crs_id",
                        column: x => x.crs_id,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CrsResults_Trainees_trainee_id",
                        column: x => x.trainee_id,
                        principalTable: "Trainees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_dept_id",
                table: "Courses",
                column: "dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_CrsResults_crs_id",
                table: "CrsResults",
                column: "crs_id");

            migrationBuilder.CreateIndex(
                name: "IX_CrsResults_trainee_id",
                table: "CrsResults",
                column: "trainee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_crs_id",
                table: "Instructors",
                column: "crs_id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_dept_id",
                table: "Instructors",
                column: "dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_dept_id",
                table: "Trainees",
                column: "dept_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrsResults");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
