using Microsoft.EntityFrameworkCore.Migrations;

namespace Life_foods_api_csharp.Migrations
{
    public partial class create_food_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Carbs = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Fats = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Proteins = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Energy = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodId);
                    table.UniqueConstraint("AK_Foods_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "IngredientNames",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientNames", x => x.IngredientId);
                    table.UniqueConstraint("AK_IngredientNames_IngredientName", x => x.IngredientName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "IngredientNames");
        }
    }
}
