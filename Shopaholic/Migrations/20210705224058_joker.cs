using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopwise.Migrations
{
    public partial class joker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_SizeToProduct_SizeToProductId",
                table: "SaleItems");

            migrationBuilder.DropTable(
                name: "ColorToProduct");

            migrationBuilder.DropTable(
                name: "SizeToProduct");

            migrationBuilder.RenameColumn(
                name: "SizeToProductId",
                table: "SaleItems",
                newName: "AllInfoToProductId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleItems_SizeToProductId",
                table: "SaleItems",
                newName: "IX_SaleItems_AllInfoToProductId");

            migrationBuilder.CreateTable(
                name: "AllInfoToProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountDeadline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllInfoToProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllInfoToProducts_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllInfoToProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllInfoToProducts_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllInfoToProducts_ColorId",
                table: "AllInfoToProducts",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_AllInfoToProducts_ProductId",
                table: "AllInfoToProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AllInfoToProducts_SizeId",
                table: "AllInfoToProducts",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_AllInfoToProducts_AllInfoToProductId",
                table: "SaleItems",
                column: "AllInfoToProductId",
                principalTable: "AllInfoToProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_AllInfoToProducts_AllInfoToProductId",
                table: "SaleItems");

            migrationBuilder.DropTable(
                name: "AllInfoToProducts");

            migrationBuilder.RenameColumn(
                name: "AllInfoToProductId",
                table: "SaleItems",
                newName: "SizeToProductId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleItems_AllInfoToProductId",
                table: "SaleItems",
                newName: "IX_SaleItems_SizeToProductId");

            migrationBuilder.CreateTable(
                name: "ColorToProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorToProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorToProduct_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorToProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SizeToProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeToProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SizeToProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SizeToProduct_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorToProduct_ColorId",
                table: "ColorToProduct",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorToProduct_ProductId",
                table: "ColorToProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeToProduct_ProductId",
                table: "SizeToProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SizeToProduct_SizeId",
                table: "SizeToProduct",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_SizeToProduct_SizeToProductId",
                table: "SaleItems",
                column: "SizeToProductId",
                principalTable: "SizeToProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
