using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class testsdfsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ ProductInCategories_Categories_CategoryId",
                table: " ProductInCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ ProductInCategories_Products_ProductId",
                table: " ProductInCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ ProductInCategories",
                table: " ProductInCategories");

            migrationBuilder.RenameTable(
                name: " ProductInCategories",
                newName: "ProductInCategories");

            migrationBuilder.RenameIndex(
                name: "IX_ ProductInCategories_ProductId",
                table: "ProductInCategories",
                newName: "IX_ProductInCategories_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInCategories",
                table: "ProductInCategories",
                columns: new[] { "CategoryId", "ProductId" });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "534b197d-59be-49fa-b109-3f4765702048");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b4d6e1c-ea67-4af9-93fa-1fd5c7f1e201", "AQAAAAEAACcQAAAAEK+9zwo+hPllBcQ9ZPV4sbxVkln6+Q2Vi1y07JuITQwtJ8iFnsdYgUQrasz3qdWV6A==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 6, 19, 17, 23, 22, 59, DateTimeKind.Local).AddTicks(1919));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInCategories_Categories_CategoryId",
                table: "ProductInCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInCategories_Products_ProductId",
                table: "ProductInCategories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInCategories_Categories_CategoryId",
                table: "ProductInCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInCategories_Products_ProductId",
                table: "ProductInCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInCategories",
                table: "ProductInCategories");

            migrationBuilder.RenameTable(
                name: "ProductInCategories",
                newName: " ProductInCategories");

            migrationBuilder.RenameIndex(
                name: "IX_ProductInCategories_ProductId",
                table: " ProductInCategories",
                newName: "IX_ ProductInCategories_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ ProductInCategories",
                table: " ProductInCategories",
                columns: new[] { "CategoryId", "ProductId" });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "3a1929d3-b49b-4b00-868c-6e25e1e079fe");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3e715894-d78e-4b8b-a9ee-c879bc59f8ab", "AQAAAAEAACcQAAAAEPiRIYXxxG4MJvaC8SnzWVnFLHRdon/3CW6iPKC5igLyjiIbFDFe9wp0atfr3y+ZUw==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 6, 18, 21, 25, 49, 516, DateTimeKind.Local).AddTicks(6628));

            migrationBuilder.AddForeignKey(
                name: "FK_ ProductInCategories_Categories_CategoryId",
                table: " ProductInCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ ProductInCategories_Products_ProductId",
                table: " ProductInCategories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
