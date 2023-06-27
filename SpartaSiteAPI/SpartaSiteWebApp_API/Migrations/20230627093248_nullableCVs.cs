﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpartaSiteWebApp_API.Migrations
{
    /// <inheritdoc />
    public partial class nullableCVs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CVs_CVId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "CVId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CVs_CVId",
                table: "Users",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "CVId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_CVs_CVId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "CVId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_CVs_CVId",
                table: "Users",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "CVId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
