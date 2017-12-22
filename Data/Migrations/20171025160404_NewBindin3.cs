using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JDPesca.Data.Migrations
{
    public partial class NewBindin3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoryCategoriesID",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryCategoriesID",
                table: "Products",
                column: "CategoryCategoriesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryCategoriesID",
                table: "Products",
                column: "CategoryCategoriesID",
                principalTable: "Categories",
                principalColumn: "CategoriesID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryCategoriesID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryCategoriesID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryCategoriesID",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                nullable: true);
        }
    }
}
