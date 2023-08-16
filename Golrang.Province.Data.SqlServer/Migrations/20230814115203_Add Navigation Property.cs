using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Golrang.Province.Data.SqlServer.Migrations
{
    public partial class AddNavigationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProvinceId",
                table: "ProvinceCity",
                type: "nvarchar(128)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProvinceCity_ProvinceId",
                table: "ProvinceCity",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProvinceCity_Province_ProvinceId",
                table: "ProvinceCity",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProvinceCity_Province_ProvinceId",
                table: "ProvinceCity");

            migrationBuilder.DropIndex(
                name: "IX_ProvinceCity_ProvinceId",
                table: "ProvinceCity");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "ProvinceCity");
        }
    }
}
