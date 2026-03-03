using System.Text.Json.Serialization;

namespace stdray.Ya300;

public record Ya300ClientResponse(
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("sharing_url")] string? SharingUrl);