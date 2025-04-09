using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobDescriptionGenerator.Migrations
{
    /// <inheritdoc />
    public partial class AddJobLevelTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobLevelName",
                table: "JobTitles",
                newName: "JobTitleCode");

            migrationBuilder.AddColumn<int>(
                name: "JobLevelId",
                table: "JobTitles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "JobFamilyAlias",
                table: "JobFamilies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "JobLevels",
                columns: table => new
                {
                    JobLevelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobLevelName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobLevels", x => x.JobLevelId);
                });

            migrationBuilder.UpdateData(
                table: "JobFamilies",
                keyColumn: "JobFamilyId",
                keyValue: 1,
                column: "JobFamilyAlias",
                value: "ENG");

            migrationBuilder.UpdateData(
                table: "JobFamilies",
                keyColumn: "JobFamilyId",
                keyValue: 2,
                column: "JobFamilyAlias",
                value: "OPS");

            migrationBuilder.InsertData(
                table: "JobLevels",
                columns: new[] { "JobLevelId", "JobLevelName" },
                values: new object[,]
                {
                    { 4, "Job Level - 4" },
                    { 5, "Job Level - 5" },
                    { 6, "Job Level - 6" },
                    { 7, "Job Level - 7" },
                    { 8, "Job Level - 8" },
                    { 9, "Job Level - 9" },
                    { 10, "Job Level - 10" },
                    { 11, "Job Level - 11" }
                });

            migrationBuilder.UpdateData(
                table: "JobTitles",
                keyColumn: "JobTitleId",
                keyValue: 1,
                columns: new[] { "JobLevelId", "JobTitleCode" },
                values: new object[] { 4, "SE1" });

            migrationBuilder.UpdateData(
                table: "JobTitles",
                keyColumn: "JobTitleId",
                keyValue: 2,
                columns: new[] { "JobLevelId", "JobTitleCode" },
                values: new object[] { 6, "SE2" });

            migrationBuilder.UpdateData(
                table: "JobTitles",
                keyColumn: "JobTitleId",
                keyValue: 3,
                columns: new[] { "JobLevelId", "JobTitleCode" },
                values: new object[] { 5, "OA1" });

            migrationBuilder.UpdateData(
                table: "JobTitles",
                keyColumn: "JobTitleId",
                keyValue: 4,
                columns: new[] { "JobLevelId", "JobTitleCode" },
                values: new object[] { 8, "LM1" });

            migrationBuilder.CreateIndex(
                name: "IX_JobTitles_JobLevelId",
                table: "JobTitles",
                column: "JobLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTitles_JobLevels_JobLevelId",
                table: "JobTitles",
                column: "JobLevelId",
                principalTable: "JobLevels",
                principalColumn: "JobLevelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTitles_JobLevels_JobLevelId",
                table: "JobTitles");

            migrationBuilder.DropTable(
                name: "JobLevels");

            migrationBuilder.DropIndex(
                name: "IX_JobTitles_JobLevelId",
                table: "JobTitles");

            migrationBuilder.DropColumn(
                name: "JobLevelId",
                table: "JobTitles");

            migrationBuilder.DropColumn(
                name: "JobFamilyAlias",
                table: "JobFamilies");

            migrationBuilder.RenameColumn(
                name: "JobTitleCode",
                table: "JobTitles",
                newName: "JobLevelName");

            migrationBuilder.UpdateData(
                table: "JobTitles",
                keyColumn: "JobTitleId",
                keyValue: 1,
                column: "JobLevelName",
                value: "Job Level - 4");

            migrationBuilder.UpdateData(
                table: "JobTitles",
                keyColumn: "JobTitleId",
                keyValue: 2,
                column: "JobLevelName",
                value: "Job Level - 6");

            migrationBuilder.UpdateData(
                table: "JobTitles",
                keyColumn: "JobTitleId",
                keyValue: 3,
                column: "JobLevelName",
                value: "Job Level - 5");

            migrationBuilder.UpdateData(
                table: "JobTitles",
                keyColumn: "JobTitleId",
                keyValue: 4,
                column: "JobLevelName",
                value: "Job Level - 8");
        }
    }
}
