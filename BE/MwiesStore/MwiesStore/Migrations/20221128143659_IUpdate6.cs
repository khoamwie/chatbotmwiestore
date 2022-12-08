using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MwiesStore.Migrations
{
    public partial class IUpdate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "DateUpdate",
                table: "Reviews",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DateUpdate",
                table: "Comments",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Reviews",
                newName: "DateUpdate");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Comments",
                newName: "DateUpdate");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
