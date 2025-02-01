using System.Linq.Expressions;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using WhoIsGayApi.Controllers;
using WhoIsGayApi.Interfaces;
using WhoIsGayApi.Classes;
using WhoIsGayApi.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using io.fusionauth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Tokens;
using WhoIsGayApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    }) 
    .AddOpenIdConnect(options =>
    {
        options.Authority = "http://localhost:8081/realms/wawarealm"; //http://localhost:8081/realms/wawarealm/protocol/openid-connect/auth
        options.ClientId = "wawaclient";
        options.ClientSecret = "UxBgVWVpD9Zz4C3F9X4SjwwZpjSgbZmn";
        options.ResponseType = "code";
        options.RequireHttpsMetadata = false;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.SaveTokens = true;
        options.Scope.Add("profile");
        options.Scope.Add("openid");
        options.Scope.Add("email");
        options.Scope.Add("offline_access");
        options.CallbackPath = "/api/test/gagabuga";
        options.SkipUnrecognizedRequests = true;
        options.ClaimActions.MapAll();
        //http://localhost:8081/realms/wawarealm/protocol/openid-connect/auth?client_id=wawaclient&redirect_uri=http%3A%2F%2Flocalhost%3A5240%2Fapi%2Ftest%2Fgagabuga&response_type=code&scope=openid
        
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContextFactory<OrderContext>();

builder.Services.AddTransient<OrderContext>();
builder.Services.AddTransient<IOrder, Order>();
builder.Services.AddTransient<HttpClient>();

var app = builder.Build();

app.MapControllers();
app.UseAuthentication(); 
app.UseAuthorization();
app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
