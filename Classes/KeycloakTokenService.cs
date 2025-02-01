using System.Net.Http.Headers;
using WhoIsGayApi.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace WhoIsGayApi.Classes;

public class KeycloakTokenService(HttpClient httpClient)
{
    public async Task<string> GetAccessTokenAsync()
    {
        var tokenEndpoint = "http://localhost:8081/realms/master/protocol/openid-connect/token";

        var requestData = new Dictionary<string, string>()
        {
            {"grant_type", "password"},
            {"username", "admin"},
            {"password", "admin"},
            {"client_id", "admin-cli"}
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
        /*
        var client = new HttpClient();
        var keycloakUrl = "http://localhost:8081/realms/master/protocol/openid-connect/token";

        var content = new StringContent(
            "client_id=admin-cli&username=admin&password=admin-password&grant_type=password",
            Encoding.UTF8,
            "application/x-www-form-urlencoded");

        var response = await client.PostAsync(keycloakUrl, content);
        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result); // Здесь вы получите токен в формате JSON
        return result;*/
    }
     
}