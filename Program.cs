using System.Linq.Expressions;
using System.Net.WebSockets;
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
        options.CallbackPath = "/test/index";
        options.SkipUnrecognizedRequests = true;
        options.ClaimActions.MapAll();
        //http://localhost:8081/realms/wawarealm/protocol/openid-connect/auth?client_id=wawaclient&redirect_uri=http%3A%2F%2Flocalhost%3A5240%2Ftest%2Findex&response_type=code&scope=openid
        
    });

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContextFactory<OrderContext>();
builder.Services.AddDbContextFactory<MessagesContext>();

builder.Services.AddTransient<OrderContext>();
builder.Services.AddTransient<MessagesContext>();
builder.Services.AddTransient<HttpClient>();
builder.Services.AddTransient<WebSocketHandler>();

var app = builder.Build();

app.UseWebSockets();
app.UseAuthentication(); 
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//Надо сказать, что получается, что все запросы проходят через "основную точку", а метод Use() в этой самой точке ловит запрос и что либо с ним делает. 
//Конкретно этот код сначала проверяет путь запроса, а после, если это /ws, то принимает соединение в новый экземпляр WebSocket, а метод Echo(который я еще не написал)
//Будет это соединение обрабатывать и пока хз как. Если путь запроса не /ws, то оно просто станет ожидать следующего запроса и повторит с ним такой же хентай.
/*app.Use(async (context, next) =>
{
    if (context.Request.Path == "/ws")
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await context.WebSockets.AcceptWebSocketAsync();
            var webSocketHandler = new WebSocketHandler(app.Services.GetRequiredService<IHttpContextAccessor>());
            await webSocketHandler.HandleConnection(webSocket); //HandleConnection обрабатывает соединение
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;  
        }
    }
    else
    {
        await next(context);
    }
});

WebSocketHandler wawa = new WebSocketHandler(app.Services.GetRequiredService<IHttpContextAccessor>());*/

app.Run();



