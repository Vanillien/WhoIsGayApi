using System.Linq.Expressions;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using WhoIsGayApi.Controllers;
using WhoIsGayApi.Models.Interfaces;
using WhoIsGayApi.Models.Classes;
using WhoIsGayApi.Models.Interfaces;
using Aspire.Hosting.Keycloak;
using IdentityModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = "Cookies";
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie("Cookies")
    .AddKeycloakOpenIdConnect("keycloak", realm: "wawarealm", options =>
    {
        options.Authority = "http://localhost:8081/auth/realms/wawarealm";
        options.ClientId = "whoisg";
        options.ClientSecret = "Iwgvp5XSO65B10WH7To5jpH7rfkIqrrJ"; 
        options.ResponseType = "code"; 
        options.Scope.Add("openid"); //добавление Scope. "openid" - это стандартно так.
        options.SaveTokens = true;
        options.CallbackPath = "/*"; //установка Callback URI
        options.SignedOutCallbackPath = "/*"; //путь к той странице, куда ты попадешь после того, как разовтаризуешься
        options.RequireHttpsMetadata = false; //потом HTTPS жахнем
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContextFactory<PersonContext>();

builder.Services.AddTransient<PersonContext>();
builder.Services.AddTransient<IPerson, Person>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IUser, User>();
builder.Services.AddTransient<HttpClient>();
builder.Services.AddSingleton<KeycloakTokenService>();
builder.Services.AddSingleton<KeycloakClient>();

var app = builder.Build();

app.MapControllers();
app.UseAuthentication(); //Кто ты?
app.UseAuthorization(); //Что тебе разрешено делать?

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();