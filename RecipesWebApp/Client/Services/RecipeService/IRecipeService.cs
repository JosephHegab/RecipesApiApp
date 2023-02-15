using RecipesWebApp.Shared;

namespace RecipesWebApp.Client.Services.RecipeService
{
    public interface IRecipeService
    {
        List<RecipeModel> Recipes { get; set; }

        List<RecipeCategoriesModel> RecipeCategories { get; set; }

        Task GetRecipeCategories();

        Task GetRecipes();

        Task<RecipeModel> GetSingleRecipe(int id);

        Task CreateRecipe(RecipeModel recipe);
        Task UpdateRecipe(RecipeModel recipe);
        Task DeleteRecipe(int id);
    }
}
