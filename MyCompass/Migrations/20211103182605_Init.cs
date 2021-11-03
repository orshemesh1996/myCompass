using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCompass.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlacesModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacesModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripCategoriesModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripCategoriesModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "PlaceImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceImage_PlacesModel_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "PlacesModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripEventModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripEventModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripEventModel_PlacesModel_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "PlacesModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripCategoriesTripEvent",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    TripEventsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripCategoriesTripEvent", x => new { x.CategoriesId, x.TripEventsId });
                    table.ForeignKey(
                        name: "FK_TripCategoriesTripEvent_TripCategoriesModel_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "TripCategoriesModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripCategoriesTripEvent_TripEventModel_TripEventsId",
                        column: x => x.TripEventsId,
                        principalTable: "TripEventModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaceImage_PlaceId",
                table: "PlaceImage",
                column: "PlaceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripCategoriesTripEvent_TripEventsId",
                table: "TripCategoriesTripEvent",
                column: "TripEventsId");

            migrationBuilder.CreateIndex(
                name: "IX_TripEventModel_PlaceId",
                table: "TripEventModel",
                column: "PlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaceImage");

            migrationBuilder.DropTable(
                name: "TripCategoriesTripEvent");

            migrationBuilder.DropTable(
                name: "UserModel");

            migrationBuilder.DropTable(
                name: "TripCategoriesModel");

            migrationBuilder.DropTable(
                name: "TripEventModel");

            migrationBuilder.DropTable(
                name: "PlacesModel");
        }
    }
}
