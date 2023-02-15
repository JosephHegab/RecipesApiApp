using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipesWebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeCategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipeCategories_RecipeCategoriesId",
                        column: x => x.RecipeCategoriesId,
                        principalTable: "RecipeCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Meat" },
                    { 2, "Fish" },
                    { 3, "Chicken" },
                    { 4, "Vegan" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "RecipeCategoriesId", "RecipeDescription", "RecipeName" },
                values: new object[,]
                {
                    { 1, 1, "Ingredients:\r\n\r\n2 (8 oz) ribeye steaks, at room temperature\r\nSalt and freshly ground black pepper\r\n2 teaspoons olive oil\r\nInstructions:\r\n\r\nRemove the steaks from the refrigerator and let them sit at room temperature for 30 minutes to an hour.\r\nPreheat your grill to high heat. Clean and oil the grates.\r\nSeason the steaks generously on both sides with salt and pepper.\r\nBrush each steak with olive oil.\r\nPlace the steaks on the hot grill, making sure they have plenty of space in between.\r\nCook for 4-5 minutes on each side for medium-rare, or until the desired level of doneness is reached.\r\nTake the steaks off the grill and let them rest for 5-10 minutes to allow the juices to redistribute.\r\nServe with your favorite sides and enjoy!\r\nNote: Cooking times may vary depending on the thickness of the steaks and the heat of your grill, so use a meat thermometer to ensure that they are cooked to your liking. For medium-rare, the internal temperature should be around 130°F.\r\n\r\n\r\n\r\n\r\n", "ribeye steaks" },
                    { 2, 2, "Ingredients:\r\n\r\n4 salmon fillets, about 6 ounces each\r\nSalt and freshly ground black pepper\r\n1 tablespoon olive oil\r\nLemon wedges for serving\r\nInstructions:\r\n\r\nSeason the salmon fillets on both sides with salt and pepper.\r\nHeat a large nonstick pan over medium-high heat.\r\nAdd the olive oil to the pan and swirl to coat.\r\nPlace the salmon fillets in the pan, skin-side down.\r\nCook the salmon for 4-5 minutes on each side, or until the skin is crispy and the flesh is opaque and easily flakes with a fork.\r\nServe the salmon hot with lemon wedges on the side.", "salmon fillets" },
                    { 3, 3, "Ingredients:\r\n\r\n1 whole chicken, about 4-5 pounds\r\nSalt and freshly ground black pepper\r\n1 tablespoon olive oil\r\n2 teaspoons dried thyme\r\n1 teaspoon dried rosemary\r\n1 lemon, cut into wedges\r\n4 garlic cloves, minced\r\nInstructions:\r\n\r\nPreheat the oven to 425°F.\r\nRinse the chicken inside and out and pat it dry with paper towels.\r\nSeason the chicken inside and out with salt and pepper.\r\nIn a small bowl, mix together the olive oil, thyme, rosemary, lemon wedges, and garlic.\r\nPlace the chicken in a roasting pan and spread the herb mixture over the chicken, making sure to get it into the cavity as well.\r\nRoast the chicken for about 1 hour and 15 minutes, or until the internal temperature of the thickest part of the thigh reaches 165°F.\r\nRemove the chicken from the oven and let it rest for 10-15 minutes before carving and serving.", "whole chicken" },
                    { 4, 4, "Ingredients:\r\n\r\n2 medium eggplants, sliced into rounds\r\nSalt and freshly ground black pepper\r\n2 tablespoons olive oil\r\n2 tablespoons balsamic vinegar\r\n1 teaspoon dried basil\r\n1 teaspoon dried oregano\r\n1 teaspoon dried thyme\r\n1/2 teaspoon garlic powder\r\nInstructions:\r\n\r\nPreheat your oven to 400°F. Line a large baking sheet with parchment paper.\r\nArrange the eggplant slices on the baking sheet and season with salt and pepper on both sides.\r\nDrizzle the eggplant slices with olive oil.\r\nIn a small bowl, mix together the balsamic vinegar, basil, oregano, thyme, and garlic powder.\r\nBrush the balsamic mixture over the eggplant slices.\r\nRoast the eggplant in the preheated oven for 25-30 minutes, or until tender and golden brown.\r\nServe the roasted eggplant hot, as a side dish or as a main course over a bed of rice or quinoa.", "eggplants" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeCategoriesId",
                table: "Recipes",
                column: "RecipeCategoriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "RecipeCategories");
        }
    }
}
