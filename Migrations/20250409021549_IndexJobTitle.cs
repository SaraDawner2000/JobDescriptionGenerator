using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobDescriptionGenerator.Migrations
{
    /// <inheritdoc />
    public partial class IndexJobTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobTitles_JobFamilyId",
                table: "JobTitles");

            migrationBuilder.CreateIndex(
                name: "IX_JobTitles_JobFamilyId_JobLevelId",
                table: "JobTitles",
                columns: new[] { "JobFamilyId", "JobLevelId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobTitles_JobFamilyId_JobLevelId",
                table: "JobTitles");

            migrationBuilder.CreateIndex(
                name: "IX_JobTitles_JobFamilyId",
                table: "JobTitles",
                column: "JobFamilyId");
        }
    }
}
