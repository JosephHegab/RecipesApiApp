using Microsoft.AspNetCore.Components;
using RecipesWebApp.Client.Pages;
using RecipesWebApp.Shared;
using System.Net.Http.Json;

namespace RecipesWebApp.Client.Services.RecipeService
{
    public class RecipeService : IRecipeService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public RecipeService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<RecipeModel> Recipes { get; set; } = new List<RecipeModel>();
        public List<RecipeCategoriesModel> RecipeCategories { get; set; } = new List<RecipeCategoriesModel>();

        public async Task CreateRecipe(RecipeModel recipe)
        {
            var result = await _http.PostAsJsonAsync("api/recipe", recipe);
            var response = await result.Content.ReadFromJsonAsync<List<RecipeModel>>();
            Recipes = response;
            _navigationManager.NavigateTo("recipes");
        }

        public async Task DeleteRecipe(int id)
        {
            var result = await _http.DeleteAsync($"api/recipe/{id}");
            var response = await result.Content.ReadFromJsonAsync<List<RecipeModel>>();
            Recipes = response;
            _navigationManager.NavigateTo("recipes");
        }

        public async Task GetRecipeCategories()
        {
            var result = await _http.GetFromJsonAsync<List<RecipeCategoriesModel>>("api/recipe/categories");

            if (result != null)
            {
                RecipeCategories = result;
            }
        }

        public async Task GetRecipes()
        {
            var result = await _http.GetFromJsonAsync<List<RecipeModel>>("api/recipe");

            if(result != null)
            {
                Recipes = result;
            }
        }

        public async Task<RecipeModel> GetSingleRecipe(int id)
        {
            var result = await _http.GetFromJsonAsync<RecipeModel>($"api/recipe/{id}");

            if (result != null)

            return result;

            throw new Exception("Recipe not found!");
        }

        public async Task UpdateRecipe(RecipeModel recipe)
        {
            var result = await _http.PutAsJsonAsync($"api/recipe/{recipe.Id}", recipe);
            var response = await result.Content.ReadFromJsonAsync<List<RecipeModel>>();
            Recipes = response;
            _navigationManager.NavigateTo("recipes");
        }
    }
}
