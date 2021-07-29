﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Skiverleih3.Migrations
{
    public partial class nullableForeignKeyInItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Customers_CustomerID",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Customers_CustomerID",
                table: "Items",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Customers_CustomerID",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Customers_CustomerID",
                table: "Items",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
