using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpartaSiteWebApp_API.Migrations
{
    /// <inheritdoc />
    public partial class renamedUsersToApplicantsInCareerItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareerItemUser_Users_UsersUserId",
                table: "CareerItemUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CareerItemUser",
                table: "CareerItemUser");

            migrationBuilder.DropIndex(
                name: "IX_CareerItemUser_UsersUserId",
                table: "CareerItemUser");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "CareerItemUser",
                newName: "ApplicantsUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CareerItemUser",
                table: "CareerItemUser",
                columns: new[] { "ApplicantsUserId", "CareerItemsAppliedCareerItemId" });

            migrationBuilder.CreateIndex(
                name: "IX_CareerItemUser_CareerItemsAppliedCareerItemId",
                table: "CareerItemUser",
                column: "CareerItemsAppliedCareerItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CareerItemUser_Users_ApplicantsUserId",
                table: "CareerItemUser",
                column: "ApplicantsUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareerItemUser_Users_ApplicantsUserId",
                table: "CareerItemUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CareerItemUser",
                table: "CareerItemUser");

            migrationBuilder.DropIndex(
                name: "IX_CareerItemUser_CareerItemsAppliedCareerItemId",
                table: "CareerItemUser");

            migrationBuilder.RenameColumn(
                name: "ApplicantsUserId",
                table: "CareerItemUser",
                newName: "UsersUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CareerItemUser",
                table: "CareerItemUser",
                columns: new[] { "CareerItemsAppliedCareerItemId", "UsersUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_CareerItemUser_UsersUserId",
                table: "CareerItemUser",
                column: "UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CareerItemUser_Users_UsersUserId",
                table: "CareerItemUser",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
