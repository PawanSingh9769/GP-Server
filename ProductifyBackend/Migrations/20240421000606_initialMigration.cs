using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductifyBackend.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactInformation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "SellerId", "ContactInformation", "Description", "Name" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), "target@store.com", "Target is a retail chain offering trendy merchandise, essentials, and more.", "Target" });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "SellerId", "ContactInformation", "Description", "Name" },
                values: new object[] { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), "123-456-7890", "Walmart is a multinational retail corporation known for its wide range of products and affordable prices.", "Walmart" });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "SellerId", "ContactInformation", "Description", "Name" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), "amazon@example.com", "Amazon is a global e-commerce platform offering a vast selection of products and services.", "Amazon" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Price", "ProductDescription", "ProductName", "SellerId" },
                values: new object[] { new Guid("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"), 499m, "Experience the latest in mobile tech with our Smartphone. Stunning display, powerful camera, and seamless performance.", "Smartphone", new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a") });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Price", "ProductDescription", "ProductName", "SellerId" },
                values: new object[] { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 99m, "Experience unparalleled performance and sleek design with our Premium Laptop, featuring cutting-edge technology for lightning-fast processing, vibrant visuals, and long-lasting battery life..", "Premium Laptop", new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a") });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
