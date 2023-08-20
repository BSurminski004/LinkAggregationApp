using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkAggregator.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HyperLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HyperLink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statistic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateVisit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeVisit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HyperLinkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistic_HyperLink_HyperLinkId",
                        column: x => x.HyperLinkId,
                        principalTable: "HyperLink",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statistic_HyperLinkId",
                table: "Statistic",
                column: "HyperLinkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HyperLink");

            migrationBuilder.DropTable(
                name: "Statistic");
        }
    }
}
