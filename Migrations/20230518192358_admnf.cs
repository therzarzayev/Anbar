using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    /// <inheritdoc />
    public partial class admnf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Products",
                newName: "ExDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EDate",
                table: "Products",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EDate",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ExDate",
                table: "Products",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
