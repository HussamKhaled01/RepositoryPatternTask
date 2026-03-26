using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryPatternTask.Migrations
{
    /// <inheritdoc />
    public partial class testSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", "Electronics" },
                    { "22222222-2222-2222-2222-222222222222", "Clothing" },
                    { "33333333-3333-3333-3333-333333333333", "Books" },
                    { "44444444-4444-4444-4444-444444444444", "Sports" },
                    { "55555555-5555-5555-5555-555555555555", "Food" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { "11111111-0000-0000-0000-000000000001", "11111111-1111-1111-1111-111111111111", "Laptop", 999.99m },
                    { "11111111-0000-0000-0000-000000000002", "11111111-1111-1111-1111-111111111111", "Smartphone", 699.99m },
                    { "11111111-0000-0000-0000-000000000003", "11111111-1111-1111-1111-111111111111", "Headphones", 149.99m },
                    { "11111111-0000-0000-0000-000000000004", "11111111-1111-1111-1111-111111111111", "Tablet", 499.99m },
                    { "11111111-0000-0000-0000-000000000005", "11111111-1111-1111-1111-111111111111", "Smart Watch", 249.99m },
                    { "22222222-0000-0000-0000-000000000001", "22222222-2222-2222-2222-222222222222", "T-Shirt", 19.99m },
                    { "22222222-0000-0000-0000-000000000002", "22222222-2222-2222-2222-222222222222", "Jeans", 49.99m },
                    { "22222222-0000-0000-0000-000000000003", "22222222-2222-2222-2222-222222222222", "Jacket", 89.99m },
                    { "22222222-0000-0000-0000-000000000004", "22222222-2222-2222-2222-222222222222", "Sneakers", 79.99m },
                    { "22222222-0000-0000-0000-000000000005", "22222222-2222-2222-2222-222222222222", "Hat", 14.99m },
                    { "33333333-0000-0000-0000-000000000001", "33333333-3333-3333-3333-333333333333", "Clean Code", 34.99m },
                    { "33333333-0000-0000-0000-000000000002", "33333333-3333-3333-3333-333333333333", "The Pragmatic Programmer", 39.99m },
                    { "33333333-0000-0000-0000-000000000003", "33333333-3333-3333-3333-333333333333", "Design Patterns", 44.99m },
                    { "33333333-0000-0000-0000-000000000004", "33333333-3333-3333-3333-333333333333", "C# in Depth", 29.99m },
                    { "33333333-0000-0000-0000-000000000005", "33333333-3333-3333-3333-333333333333", "ASP.NET Core", 37.99m },
                    { "44444444-0000-0000-0000-000000000001", "44444444-4444-4444-4444-444444444444", "Football", 24.99m },
                    { "44444444-0000-0000-0000-000000000002", "44444444-4444-4444-4444-444444444444", "Tennis Racket", 59.99m },
                    { "44444444-0000-0000-0000-000000000003", "44444444-4444-4444-4444-444444444444", "Yoga Mat", 29.99m },
                    { "44444444-0000-0000-0000-000000000004", "44444444-4444-4444-4444-444444444444", "Running Shoes", 89.99m },
                    { "44444444-0000-0000-0000-000000000005", "44444444-4444-4444-4444-444444444444", "Dumbbells", 39.99m },
                    { "55555555-0000-0000-0000-000000000001", "55555555-5555-5555-5555-555555555555", "Protein Bar", 2.99m },
                    { "55555555-0000-0000-0000-000000000002", "55555555-5555-5555-5555-555555555555", "Olive Oil", 9.99m },
                    { "55555555-0000-0000-0000-000000000003", "55555555-5555-5555-5555-555555555555", "Green Tea", 5.99m },
                    { "55555555-0000-0000-0000-000000000004", "55555555-5555-5555-5555-555555555555", "Almonds", 7.99m },
                    { "55555555-0000-0000-0000-000000000005", "55555555-5555-5555-5555-555555555555", "Honey", 6.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "11111111-0000-0000-0000-000000000001");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "11111111-0000-0000-0000-000000000002");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "11111111-0000-0000-0000-000000000003");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "11111111-0000-0000-0000-000000000004");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "11111111-0000-0000-0000-000000000005");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "22222222-0000-0000-0000-000000000001");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "22222222-0000-0000-0000-000000000002");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "22222222-0000-0000-0000-000000000003");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "22222222-0000-0000-0000-000000000004");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "22222222-0000-0000-0000-000000000005");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "33333333-0000-0000-0000-000000000001");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "33333333-0000-0000-0000-000000000002");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "33333333-0000-0000-0000-000000000003");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "33333333-0000-0000-0000-000000000004");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "33333333-0000-0000-0000-000000000005");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "44444444-0000-0000-0000-000000000001");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "44444444-0000-0000-0000-000000000002");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "44444444-0000-0000-0000-000000000003");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "44444444-0000-0000-0000-000000000004");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "44444444-0000-0000-0000-000000000005");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "55555555-0000-0000-0000-000000000001");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "55555555-0000-0000-0000-000000000002");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "55555555-0000-0000-0000-000000000003");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "55555555-0000-0000-0000-000000000004");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "55555555-0000-0000-0000-000000000005");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "22222222-2222-2222-2222-222222222222");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "33333333-3333-3333-3333-333333333333");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "44444444-4444-4444-4444-444444444444");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "55555555-5555-5555-5555-555555555555");
        }
    }
}
