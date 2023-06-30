using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpartaSiteWebApp_API.Migrations
{
    /// <inheritdoc />
    public partial class changedPropertyNamesInQuestionAndVideo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Videos",
                newName: "VideoId");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "Questions",
                newName: "ActualQuestion");

            migrationBuilder.RenameColumn(
                name: "QuestionBankId",
                table: "Questions",
                newName: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VideoId",
                table: "Videos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ActualQuestion",
                table: "Questions",
                newName: "Question");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Questions",
                newName: "QuestionBankId");
        }
    }
}
