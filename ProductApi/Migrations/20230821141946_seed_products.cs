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
                    {
                        Guid.Parse("2e4b8b6b-84cf-4dcd-a08a-2955cfab4dff"),
                        "Banana",
                        3.95m,
                        DateTime.UtcNow,
                        DateTime.UtcNow
                    },
                    {
                        Guid.Parse("142f229e-1ce0-45f7-a0c9-7c01e0763fb7"),
                        "Gummy bear",
                        1.00m,
                        DateTime.UtcNow,
                        DateTime.UtcNow
                    },
                    {
                        Guid.Parse("834e0d94-76f6-4406-a28d-f270075d1298"),
                        "Apple",
                        2.10m,
                        DateTime.UtcNow,
                        DateTime.UtcNow
                    },
                    {
                        Guid.Parse("ee649435-25f9-4768-b730-7952c6a09a13"),
                        "Orange",
                        1.95m,
                        DateTime.UtcNow,
                        DateTime.UtcNow
                    },
                    {
                        Guid.Parse("e5ff1ef1-5af4-4b35-b6d3-2cd80564ccd2"),
                        "Apple juice",
                        5.60m,
                        DateTime.UtcNow,
                        DateTime.UtcNow
                    },
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Products");
        }
    }
}
