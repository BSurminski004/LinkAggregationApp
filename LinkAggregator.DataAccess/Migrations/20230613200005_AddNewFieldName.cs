using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkAggregator.DataAccess.Migrations
{
    public partial class AddNewFieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HashCode",
                table: "HyperLink",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "HyperLink",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "HyperLink");

            migrationBuilder.AlterColumn<string>(
                name: "HashCode",
                table: "HyperLink",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
