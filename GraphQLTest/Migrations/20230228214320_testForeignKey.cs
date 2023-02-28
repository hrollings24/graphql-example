using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQLTest.Migrations
{
    /// <inheritdoc />
    public partial class testForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ExtendedProperties",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ExtendedProperties_ProductId",
                table: "ExtendedProperties",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtendedProperties_Products_ProductId",
                table: "ExtendedProperties",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtendedProperties_Products_ProductId",
                table: "ExtendedProperties");

            migrationBuilder.DropIndex(
                name: "IX_ExtendedProperties_ProductId",
                table: "ExtendedProperties");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ExtendedProperties");
        }
    }
}
