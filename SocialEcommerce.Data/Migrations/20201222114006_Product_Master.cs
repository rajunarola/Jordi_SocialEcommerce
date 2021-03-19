﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialEcommerce.Data.Migrations
{
    public partial class Product_Master : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_ProductMaster_UserId",
                table: "Cart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Cart_ProductMaster_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "ProductMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
