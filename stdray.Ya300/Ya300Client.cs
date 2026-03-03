using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace stdray.Ya300;

public class Ya300Client(
    ILogger<Ya300Client> logger,
    IOptionsSnapshot<Ya300ClientSettings> settings,
    HttpClient http)
{
    readonly AuthenticationHeaderValue _authHeader = new("OAuth", settings.Value.Token);

    public async Task<Ya300ClientResponse?> GetSummaryLink(Uri articleUrl)
    {
        var payload = new { article_url = articleUrl };
        var json = JsonSerializer.Serialize(payload);
        var message = new HttpRequestMessage(HttpMethod.Post, settings.Value.Url)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
        message.Headers.Authorization = _authHeader;
        logger.LogWarning("Token {Token}", settings.Value.Token);
        var response = await http.SendAsync(message);
        if (!response.IsSuccessStatusCode)
        {
            logger.LogError("Ya300 error: {ResponseStatusCode}", response.StatusCode);
            return null;
        }

        return await response.Content.ReadFromJsonAsync<Ya300ClientResponse>();
    }
}