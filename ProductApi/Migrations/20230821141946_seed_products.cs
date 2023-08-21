using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class seed_products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "CreatedAt", "ModifiedAt" },
                values: new object[,]
                {
                    { Guid.NewGuid(), "Banana", 3.95m, DateTime.UtcNow, DateTime.UtcNow },
                    { Guid.NewGuid(), "Gummy bear", 1.00m, DateTime.UtcNow, DateTime.UtcNow },
                    { Guid.NewGuid(), "Apple", 2.10m, DateTime.UtcNow, DateTime.UtcNow },
                    { Guid.NewGuid(), "Orange", 1.95m, DateTime.UtcNow, DateTime.UtcNow },
                    { Guid.NewGuid(), "Apple juice", 5.60m, DateTime.UtcNow, DateTime.UtcNow },
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
