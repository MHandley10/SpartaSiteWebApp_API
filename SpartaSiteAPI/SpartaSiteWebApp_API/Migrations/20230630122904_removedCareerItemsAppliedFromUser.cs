using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpartaSiteWebApp_API.Migrations
{
    /// <inheritdoc />
    public partial class removedCareerItemsAppliedFromUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CareerItemUser");

            migrationBuilder.AddColumn<Guid>(
                name: "CareerItemId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CareerItemId",
                table: "Users",
                column: "CareerItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CareerItems_CareerItemId",
                table: "Users",
                column: "CareerItemId",
                principalTable: "CareerItems",
                principalColumn: "CareerItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CareerItems_CareerItemId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CareerItemId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CareerItemId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "CareerItemUser",
                columns: table => new
                {
                    ApplicantsUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CareerItemsAppliedCareerItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerItemUser", x => new { x.ApplicantsUserId, x.CareerItemsAppliedCareerItemId });
                    table.ForeignKey(
                        name: "FK_CareerItemUser_CareerItems_CareerItemsAppliedCareerItemId",
                        column: x => x.CareerItemsAppliedCareerItemId,
                        principalTable: "CareerItems",
                        principalColumn: "CareerItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CareerItemUser_Users_ApplicantsUserId",
                        column: x => x.ApplicantsUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CareerItemUser_CareerItemsAppliedCareerItemId",
                table: "CareerItemUser",
                column: "CareerItemsAppliedCareerItemId");
        }
    }
}
