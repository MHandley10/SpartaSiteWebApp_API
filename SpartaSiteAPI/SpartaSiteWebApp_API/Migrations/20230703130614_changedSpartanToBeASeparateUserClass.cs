using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpartaSiteWebApp_API.Migrations
{
    /// <inheritdoc />
    public partial class changedSpartanToBeASeparateUserClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Spartans_SpartanId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SpartanId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsSpartan",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SpartanId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Spartans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Spartans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CVId",
                table: "Spartans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Spartans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryOfResidence",
                table: "Spartans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateJoined",
                table: "Spartans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Spartans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Spartans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Spartans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Spartans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Spartans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Spartans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Spartans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Spartans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Spartans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Spartans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Spartans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spartans_CVId",
                table: "Spartans",
                column: "CVId");

            migrationBuilder.AddForeignKey(
                name: "FK_Spartans_CVs_CVId",
                table: "Spartans",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "CVId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spartans_CVs_CVId",
                table: "Spartans");

            migrationBuilder.DropIndex(
                name: "IX_Spartans_CVId",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "About",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "CountryOfResidence",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "DateJoined",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Spartans");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Spartans");

            migrationBuilder.AddColumn<bool>(
                name: "IsSpartan",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SpartanId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SpartanId",
                table: "Users",
                column: "SpartanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Spartans_SpartanId",
                table: "Users",
                column: "SpartanId",
                principalTable: "Spartans",
                principalColumn: "SpartanId");
        }
    }
}
