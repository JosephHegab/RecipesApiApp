using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace RecipesWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly DataContext _context;

        public RecipeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<RecipeModel>>> GetRecipes()
        {
            var recipes = await _context.Recipes.ToListAsync();

            return Ok(recipes);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<RecipeCategoriesModel>>> GetCategories()
        {
            var recipeCategories = await _context.RecipeCategories.ToListAsync();

            return Ok(recipeCategories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<RecipeModel>>> GetSingleRecipes(int id)
        {
            var recipe = await _context.Recipes
                .Include(r => r.RecipeCategories)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null)
            {
                return NotFound("Sorry, no recipe here!");
            }
            return Ok(recipe);
        }


        [HttpPost]
        public async Task<ActionResult<List<RecipeModel>>> CreateRecipe(RecipeModel recipe)
        {
            recipe.RecipeCategories = null;
            _context.Recipes.Add(recipe);

            await _context.SaveChangesAsync();

            return Ok(await GetDbRecipes());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<RecipeModel>>> UpdateRecipe(RecipeModel recipe, int id)
        {
           var dbRecipe = await _context.Recipes
                .Include(r => r.RecipeCategories)
                .FirstOrDefaultAsync(r => r.Id == id);
            if (dbRecipe == null)
            {
                return NotFound("Sorry, Not found!");
            }

            dbRecipe.RecipeName = recipe.RecipeName;

            dbRecipe.RecipeDescription = recipe.RecipeDescription;

            dbRecipe.RecipeCategoriesId = recipe.RecipeCategoriesId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbRecipes());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<RecipeModel>>> DeleteRecipe( int id)
        {
            var dbRecipe = await _context.Recipes
                 .Include(r => r.RecipeCategories)
                 .FirstOrDefaultAsync(r => r.Id == id);
            if (dbRecipe == null)
            {
                return NotFound("Sorry, Not found!");
            }

           _context.Recipes.Remove(dbRecipe);

            await _context.SaveChangesAsync();

            return Ok(await GetDbRecipes());
        }


        private async Task<List<RecipeModel>> GetDbRecipes()
        {
            return await _context.Recipes.Include(r => r.RecipeCategories).ToListAsync();
        }


    }
}
