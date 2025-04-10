using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobDescriptionGenerator.Migrations
{
    /// <inheritdoc />
    public partial class AddJobLevelConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobTitleCode",
                table: "JobTitles",
                newName: "JobProfile");

            migrationBuilder.RenameColumn(
                name: "JobFamilyAlias",
                table: "JobFamilies",
                newName: "FutureJobFamilyName");

            migrationBuilder.AddCheckConstraint(
                name: "CK_JobTitle_JobLevel_Range",
                table: "JobTitles",
                sql: "[JobLevel] >= 4 AND [JobLevel] <= 11");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_JobTitle_JobLevel_Range",
                table: "JobTitles");

            migrationBuilder.RenameColumn(
                name: "JobProfile",
                table: "JobTitles",
                newName: "JobTitleCode");

            migrationBuilder.RenameColumn(
                name: "FutureJobFamilyName",
                table: "JobFamilies",
                newName: "JobFamilyAlias");
        }
    }
}
