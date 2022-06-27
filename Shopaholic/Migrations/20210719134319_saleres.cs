using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopwise.Migrations
{
    public partial class saleres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Sales",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Sales",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CountryId",
                table: "Sales",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Countries_CountryId",
                table: "Sales",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Countries_CountryId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CountryId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Sales");
        }
    }
}
