using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SppdDocs.Infrastructure.DbAccess.Migrations
{
	public partial class Initial : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateSequence(
				"catalog_brand_hilo",
				incrementBy: 10);

			migrationBuilder.CreateSequence(
				"catalog_hilo",
				incrementBy: 10);

			migrationBuilder.CreateSequence(
				"catalog_type_hilo",
				incrementBy: 10);

			migrationBuilder.CreateTable(
				"Baskets",
				table => new
				         {
					         Id = table.Column<int>("int", nullable: false)
					                   .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					         BuyerId = table.Column<string>("nvarchar(max)", nullable: true)
				         },
				constraints: table => { table.PrimaryKey("PK_Baskets", x => x.Id); });

			migrationBuilder.CreateTable(
				"CatalogBrand",
				table => new
				         {
					         Id = table.Column<int>("int", nullable: false),
					         Brand = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: false)
				         },
				constraints: table => { table.PrimaryKey("PK_CatalogBrand", x => x.Id); });

			migrationBuilder.CreateTable(
				"CatalogType",
				table => new
				         {
					         Id = table.Column<int>("int", nullable: false),
					         Type = table.Column<string>("nvarchar(100)", maxLength: 100, nullable: false)
				         },
				constraints: table => { table.PrimaryKey("PK_CatalogType", x => x.Id); });

			migrationBuilder.CreateTable(
				"Orders",
				table => new
				         {
					         Id = table.Column<int>("int", nullable: false)
					                   .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					         BuyerId = table.Column<string>("nvarchar(max)", nullable: true),
					         OrderDate = table.Column<DateTimeOffset>("datetimeoffset", nullable: false),
					         ShipToAddress_City = table.Column<string>("nvarchar(max)", nullable: true),
					         ShipToAddress_Country = table.Column<string>("nvarchar(max)", nullable: true),
					         ShipToAddress_State = table.Column<string>("nvarchar(max)", nullable: true),
					         ShipToAddress_Street = table.Column<string>("nvarchar(max)", nullable: true),
					         ShipToAddress_ZipCode = table.Column<string>("nvarchar(max)", nullable: true)
				         },
				constraints: table => { table.PrimaryKey("PK_Orders", x => x.Id); });

			migrationBuilder.CreateTable(
				"BasketItem",
				table => new
				         {
					         Id = table.Column<int>("int", nullable: false)
					                   .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					         BasketId = table.Column<int>("int", nullable: true),
					         CatalogItemId = table.Column<int>("int", nullable: false),
					         Quantity = table.Column<int>("int", nullable: false),
					         UnitPrice = table.Column<decimal>("decimal(18, 2)", nullable: false)
				         },
				constraints: table =>
				{
					table.PrimaryKey("PK_BasketItem", x => x.Id);
					table.ForeignKey(
						"FK_BasketItem_Baskets_BasketId",
						x => x.BasketId,
						"Baskets",
						"Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				"Catalog",
				table => new
				         {
					         Id = table.Column<int>("int", nullable: false),
					         CatalogBrandId = table.Column<int>("int", nullable: false),
					         CatalogTypeId = table.Column<int>("int", nullable: false),
					         Description = table.Column<string>("nvarchar(max)", nullable: true),
					         Name = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
					         PictureUri = table.Column<string>("nvarchar(max)", nullable: true),
					         Price = table.Column<decimal>("decimal(18, 2)", nullable: false)
				         },
				constraints: table =>
				{
					table.PrimaryKey("PK_Catalog", x => x.Id);
					table.ForeignKey(
						"FK_Catalog_CatalogBrand_CatalogBrandId",
						x => x.CatalogBrandId,
						"CatalogBrand",
						"Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						"FK_Catalog_CatalogType_CatalogTypeId",
						x => x.CatalogTypeId,
						"CatalogType",
						"Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				"OrderItems",
				table => new
				         {
					         Id = table.Column<int>("int", nullable: false)
					                   .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
					         OrderId = table.Column<int>("int", nullable: true),
					         UnitPrice = table.Column<decimal>("decimal(18, 2)", nullable: false),
					         Units = table.Column<int>("int", nullable: false),
					         ItemOrdered_CatalogItemId = table.Column<int>("int", nullable: false),
					         ItemOrdered_PictureUri = table.Column<string>("nvarchar(max)", nullable: true),
					         ItemOrdered_ProductName = table.Column<string>("nvarchar(max)", nullable: true)
				         },
				constraints: table =>
				{
					table.PrimaryKey("PK_OrderItems", x => x.Id);
					table.ForeignKey(
						"FK_OrderItems_Orders_OrderId",
						x => x.OrderId,
						"Orders",
						"Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				"IX_BasketItem_BasketId",
				"BasketItem",
				"BasketId");

			migrationBuilder.CreateIndex(
				"IX_Catalog_CatalogBrandId",
				"Catalog",
				"CatalogBrandId");

			migrationBuilder.CreateIndex(
				"IX_Catalog_CatalogTypeId",
				"Catalog",
				"CatalogTypeId");

			migrationBuilder.CreateIndex(
				"IX_OrderItems_OrderId",
				"OrderItems",
				"OrderId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				"BasketItem");

			migrationBuilder.DropTable(
				"Catalog");

			migrationBuilder.DropTable(
				"OrderItems");

			migrationBuilder.DropTable(
				"Baskets");

			migrationBuilder.DropTable(
				"CatalogBrand");

			migrationBuilder.DropTable(
				"CatalogType");

			migrationBuilder.DropTable(
				"Orders");

			migrationBuilder.DropSequence(
				"catalog_brand_hilo");

			migrationBuilder.DropSequence(
				"catalog_hilo");

			migrationBuilder.DropSequence(
				"catalog_type_hilo");
		}
	}
}