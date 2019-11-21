﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopPodaci.Migrations
{
    public partial class migV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cardtype",
                columns: table => new
                {
                    CardTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cardtype", x => x.CardTypeID);
                });

            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    CartID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart", x => x.CartID);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    CityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(nullable: true),
                    PostCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "gender",
                columns: table => new
                {
                    GenderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "manufacturer",
                columns: table => new
                {
                    ManufacturerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerName = table.Column<string>(nullable: true),
                    LogoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturer", x => x.ManufacturerID);
                });

            migrationBuilder.CreateTable(
                name: "creditcard",
                columns: table => new
                {
                    CreditCardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardTypeID = table.Column<int>(nullable: true),
                    CreditCardNumber = table.Column<int>(nullable: false),
                    CSC = table.Column<int>(nullable: false),
                    ExpMonth = table.Column<int>(nullable: false),
                    ExpYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creditcard", x => x.CreditCardID);
                    table.ForeignKey(
                        name: "FK_creditcard_cardtype_CardTypeID",
                        column: x => x.CardTypeID,
                        principalTable: "cardtype",
                        principalColumn: "CardTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "subcategory",
                columns: table => new
                {
                    SubCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(nullable: false),
                    SubCategoryName = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subcategory", x => x.SubCategoryID);
                    table.ForeignKey(
                        name: "FK_subcategory_category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    CityID = table.Column<int>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    GenderID = table.Column<int>(nullable: true),
                    CreditCardID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_user_city_CityID",
                        column: x => x.CityID,
                        principalTable: "city",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_creditcard_CreditCardID",
                        column: x => x.CreditCardID,
                        principalTable: "creditcard",
                        principalColumn: "CreditCardID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNumber = table.Column<string>(nullable: true),
                    SubCategoryID = table.Column<int>(nullable: true),
                    ManufacturerID = table.Column<int>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_product_manufacturer_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "manufacturer",
                        principalColumn: "ManufacturerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_subcategory_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalTable: "subcategory",
                        principalColumn: "SubCategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    ShipDate = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_order_cart_OrderID",
                        column: x => x.OrderID,
                        principalTable: "cart",
                        principalColumn: "CartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_user_UserID",
                        column: x => x.UserID,
                        principalTable: "user",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cartdetails",
                columns: table => new
                {
                    CartID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartdetails", x => new { x.CartID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_cartdetails_cart_CartID",
                        column: x => x.CartID,
                        principalTable: "cart",
                        principalColumn: "CartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cartdetails_product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartdetails_ProductID",
                table: "cartdetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_creditcard_CardTypeID",
                table: "creditcard",
                column: "CardTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_order_UserID",
                table: "order",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_product_ManufacturerID",
                table: "product",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_product_SubCategoryID",
                table: "product",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_subcategory_CategoryID",
                table: "subcategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_user_CityID",
                table: "user",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_user_CreditCardID",
                table: "user",
                column: "CreditCardID");

            migrationBuilder.CreateIndex(
                name: "IX_user_GenderID",
                table: "user",
                column: "GenderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartdetails");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "manufacturer");

            migrationBuilder.DropTable(
                name: "subcategory");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "creditcard");

            migrationBuilder.DropTable(
                name: "gender");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "cardtype");
        }
    }
}