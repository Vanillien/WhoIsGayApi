using System.Linq.Expressions;
using WhoIsGayApi.Classes;
using Microsoft.EntityFrameworkCore;
using WhoIsGayApi.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddTransient<AppDbContext>();
builder.Services.AddSingleton<DbSet<Person>>();
builder.Services.AddSingleton<Node>();
builder.Services.AddSingleton<IServiceProvider, ServiceProvider>();
builder.Services.AddSingleton<Type>();
builder.Services.AddSingleton<Expression>();
//builder.Services.AddSingleton<IQueryProvider>();
builder.Services.AddSingleton<IPerson, Person>();
builder.Services.AddSingleton<IPersonBuilder, PersonBuilder>();

/*var serviceProvider = builder.Services.BuildServiceProvider();
var personBuilder = serviceProvider.GetRequiredService<PersonBuilder>();
personBuilder.SetFirstName("");
personBuilder.SetLastName("");
personBuilder.SetGay();
IPerson result = personBuilder.BuildPerson();*/

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