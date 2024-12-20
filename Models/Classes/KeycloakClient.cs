using System.Net.Http.Headers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WhoIsGayApi.Models.Interfaces;

namespace WhoIsGayApi.Models.Classes;

public class KeycloakClient //это ащтидипи клиент персонально для keycloak. Как PersonContext и DbContext
{
    private readonly HttpClient _httpClient;
    private readonly KeycloakTokenService _tokenService;
    
    
    public KeycloakClient(HttpClient httpClient, KeycloakTokenService tokenService)
    {
        _httpClient = httpClient;
        _tokenService = tokenService;
        _httpClient.BaseAddress = new Uri("http://localhost:8081/admin/realms/wawarealm/");//"http://localhost:8081/admin/realms/wawarealm/"
    }

    public async Task CreateUserAsync(User user)//UserKeycloakDto
    {
        var adminToken = await _tokenService.GetAccessTokenAsync();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", adminToken);
        var response = await _httpClient.PostAsJsonAsync("users", user); //"response" translate as "Ответ"
        response.EnsureSuccessStatusCode();
    }
    
}