using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Golrang.Province.Data.SqlServer.Migrations
{
    public partial class ChageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "ProvinceCity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProvinceCity",
                table: "ProvinceCity",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProvinceCity",
                table: "ProvinceCity");

            migrationBuilder.RenameTable(
                name: "ProvinceCity",
                newName: "City");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");
        }
    }
}
