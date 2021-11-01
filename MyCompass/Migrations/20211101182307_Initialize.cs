using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCompass.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "PlaceImage");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "PlaceImage",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "PlaceImage");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "PlaceImage",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
