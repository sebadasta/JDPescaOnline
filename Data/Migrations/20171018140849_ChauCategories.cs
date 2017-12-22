using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JDPesca.Data.Migrations
{
    public partial class ChauCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryCategoriesID",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
