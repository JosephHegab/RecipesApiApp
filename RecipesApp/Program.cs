using Newtonsoft.Json;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(hc => new HttpClient {BaseAddress = new Uri("https://recipesbank.azurewebsites.net/") });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/recipe", async(HttpClient httpClient) => {
    return await httpClient.GetFromJsonAsync<List<Post>>("/recipe");
});

app.MapDelete("/recipe/{id}", async (HttpClient httpClient, string id) => {
    var response = await httpClient.DeleteAsync($"/recipe/{id}");
    return response.IsSuccessStatusCode;
});

app.MapPost("/recipe", async (HttpClient httpClient, Post recipe) => {
    var content = new StringContent(JsonConvert.SerializeObject(recipe), Encoding.UTF8, "application/json");
    var response = await httpClient.PostAsync("/recipe", content);
    return response.IsSuccessStatusCode;
});



app.Run();

class Post
{
   
    public string _id { get; set; }
    public string recipeName { get; set; }
    public string recipe { get; set; }
}