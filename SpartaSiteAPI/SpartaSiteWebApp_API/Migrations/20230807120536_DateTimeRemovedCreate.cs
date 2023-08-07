using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpartaSiteWebApp_API.Migrations
{
    /// <inheritdoc />
    public partial class DateTimeRemovedCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareerItems_Spartans_SpartanId",
                table: "CareerItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpartanId",
                table: "CareerItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsFilled",
                table: "CareerItems",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddForeignKey(
                name: "FK_CareerItems_Spartans_SpartanId",
                table: "CareerItems",
                column: "SpartanId",
                principalTable: "Spartans",
                principalColumn: "SpartanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CareerItems_Spartans_SpartanId",
                table: "CareerItems");

            migrationBuilder.AlterColumn<Guid>(
                name: "SpartanId",
                table: "CareerItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsFilled",
                table: "CareerItems",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CareerItems_Spartans_SpartanId",
                table: "CareerItems",
                column: "SpartanId",
                principalTable: "Spartans",
                principalColumn: "SpartanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
