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
                    JobFamilyName = table.Column<string>(type: "TEXT", nullable: false),
                    JobFamilyAlias = table.Column<string>(type: "TEXT", nullable: false)
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
                    JobTitleCode = table.Column<string>(type: "TEXT", nullable: false),
                    JobFamilyId = table.Column<int>(type: "INTEGER", nullable: false),
                    JobLevel = table.Column<int>(type: "INTEGER", nullable: false)
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
                columns: new[] { "JobFamilyId", "JobFamilyAlias", "JobFamilyName" },
                values: new object[,]
                {
                    { 1, "ENG", "Engineering" },
                    { 2, "OPS", "Operations" }
                });

            migrationBuilder.InsertData(
                table: "JobTitles",
                columns: new[] { "JobTitleId", "JobFamilyId", "JobLevel", "JobTitleCode", "JobTitleName" },
                values: new object[,]
                {
                    { 1, 1, 4, "SE1", "Software Engineer" },
                    { 2, 1, 6, "SE2", "Senior Software Engineer" },
                    { 3, 2, 5, "OA1", "Operations Analyst" },
                    { 4, 2, 8, "LM1", "Logistics Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobTitles_JobFamilyId_JobLevel",
                table: "JobTitles",
                columns: new[] { "JobFamilyId", "JobLevel" },
                unique: true);
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
