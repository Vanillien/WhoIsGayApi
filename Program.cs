using System.Linq.Expressions;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using WhoIsGayApi.Controllers;
using WhoIsGayApi.Models.Interfaces;
using WhoIsGayApi.Models.Classes;
using WhoIsGayApi.Models.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using io.fusionauth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Tokens;

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
        options.Authority = "http://localhost:9011";
        options.ClientId = "4130d326-4e9f-4a02-b1a0-8ac2d45a8fdd";
        options.ClientSecret = "I7GJcxoisHcjPlL0d-ByQeDlouI9vmPMVTet00Y5Rw4";
        options.ResponseType = "code";
        options.RequireHttpsMetadata = false;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.SaveTokens = true;
        options.Scope.Add("profile");
        options.Scope.Add("openid");
        options.Scope.Add("email");
        options.CallbackPath = "/auth/callback";
        options.Scope.Add("offline_access");
        options.SkipUnrecognizedRequests = true;
        /*
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = "http://localhost:9011",
            ValidAudience = "4130d326-4e9f-4a02-b1a0-8ac2d45a8fdd",
            ValidateIssuerSigningKey = true,
        };*/
    });

/*builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.Lax; // Позволяет отправлять куки в кросс-доменных запросах
});*/

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContextFactory<PersonContext>();

builder.Services.AddTransient<PersonContext>();
builder.Services.AddTransient<IPerson, Person>();
//builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddTransient<IUser, User>();
builder.Services.AddTransient<HttpClient>();
/////
/*ForwardedHeadersOptions forwardedHeadersOptions = new()
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
};
forwardedHeadersOptions.KnownNetworks.Clear();
forwardedHeadersOptions.KnownProxies.Clear();*/
////
var app = builder.Build();
/////
//app.UseForwardedHeaders();
//app.UseCookiePolicy();
////
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

//app.UseHttpsRedirection();

app.Run();
