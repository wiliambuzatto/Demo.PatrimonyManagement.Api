using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.PatrimonyManagement.Data.Migrations
{
    public partial class InitializeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogEntry",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    EntityName = table.Column<string>(nullable: true),
                    EntityId = table.Column<Guid>(nullable: false),
                    Operation = table.Column<string>(nullable: true),
                    LogDateTime = table.Column<DateTime>(nullable: false),
                    ValuesChanges = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patrimony",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 100, nullable: false),
                    BrandId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 100, nullable: true),
                    TippingNumber = table.Column<Guid>(type: "uniqueIdentifier", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrimony", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patrimony_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patrimony_BrandId",
                table: "Patrimony",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogEntry");

            migrationBuilder.DropTable(
                name: "Patrimony");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
