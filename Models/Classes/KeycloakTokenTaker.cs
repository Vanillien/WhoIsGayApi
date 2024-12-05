using System.Net.Http.Headers;
using k8s.Models;
using WhoIsGayApi.Models.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WhoIsGayApi.Models.Classes;

public class KeycloakTokenService(HttpClient httpClient)
{
    public async Task<string> GetAccessTokenAsync()
    {
        var tokenEndpoint = "http://localhost:8081/realms/wawarealm/protocol/openid-connect/token";
        var clientId = "admin-cli";
        var clientSecret = "Iwgvp5XSO65B10WH7To5jpH7rfkIqrrJ";

        var requestData = new Dictionary<string, string>()
        {
            { "grant_type", "client_credentials" },
            { "client_id", clientId },
            { "client_secret", clientSecret }
        };
        
        var requestContent = new FormUrlEncodedContent(requestData); 

        var response = await httpClient.PostAsync(tokenEndpoint, requestContent);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to obtain access token");
        }

        var content = await response.Content.ReadAsStringAsync();
        
        var accessToken = JsonConvert.DeserializeObject<JObject>(content);
        return accessToken["access_token"].ToString();
    }
    
}