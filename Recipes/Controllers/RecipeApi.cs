using Microsoft.AspNetCore.Mvc;

namespace recipes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {   private readonly HttpClient _httpClient;


        public RecipesController(HttpClient httpClient)
        {
                _httpClient= httpClient;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            var response = await _httpClient.GetAsync("https://onlinerecipes.azurewebsites.net/recipes");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Not found!");
            }
            var data = await response.Content.ReadAsStringAsync();
            return Ok(data);
        }
    }
}
