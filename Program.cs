using System.Linq.Expressions;
using WhoIsGayApi.Classes;
using Microsoft.EntityFrameworkCore;
using WhoIsGayApi.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddPooledDbContextFactory<AppDbContext>(options => 
    options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=WhoIsGayDb;User Id=postgres;Password=rr7kyy00"), 
    poolSize: 128);*/

builder.Services.AddDbContextFactory<AppDbContext>();

builder.Services.AddTransient<AppDbContext>();
builder.Services.AddSingleton<Node>();
//builder.Services.AddSingleton<IDbContextFactory<AppDbContext>>(); //Вот такую хуйню не регай, не будь ебланищем
builder.Services.AddSingleton<IPerson, Person>();
builder.Services.AddSingleton<IPersonBuilder, PersonBuilder>();

var serviceProvider = builder.Services.BuildServiceProvider();

var node = serviceProvider.GetRequiredService<Node>();
for (int i = 0; i < 100; i++)
{
    Console.WriteLine(node.GetObj("Олеже")[0].FirstName);
}
//Console.WriteLine(node.GetObj("Олеже")[0].FirstName);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/*var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();*/

app.Run();

/*record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}*/
