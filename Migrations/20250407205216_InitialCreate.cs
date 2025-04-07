using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobDescriptionGenerator.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobFamilies",
                columns: table => new
                {
                    JobFamilyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobFamilyName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobFamilies", x => x.JobFamilyId);
                });

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    JobTitleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobTitleName = table.Column<string>(type: "TEXT", nullable: false),
                    JobFamilyId = table.Column<int>(type: "INTEGER", nullable: false),
                    JobLevelName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.JobTitleId);
                    table.ForeignKey(
                        name: "FK_JobTitles_JobFamilies_JobFamilyId",
                        column: x => x.JobFamilyId,
                        principalTable: "JobFamilies",
                        principalColumn: "JobFamilyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "JobFamilies",
                columns: new[] { "JobFamilyId", "JobFamilyName" },
                values: new object[,]
                {
                    { 1, "Engineering" },
                    { 2, "Operations" }
                });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "JobTitleId", "JobFamilyId", "JobLevelName", "JobTitleName" },
                values: new object[,]
                {
                    { 1, 1, "Job Level - 4", "Software Engineer" },
                    { 2, 1, "Job Level - 6", "Senior Software Engineer" },
                    { 3, 2, "Job Level - 5", "Operations Analyst" },
                    { 4, 2, "Job Level - 8", "Logistics Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobTitles_JobFamilyId",
                table: "JobTitles",
                column: "JobFamilyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "JobFamilies");
        }
    }
}
