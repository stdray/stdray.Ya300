namespace stdray.Ya300;

public class Ya300ClientSettings
{
    public required string Url { get; init; } = "https://300.ya.ru/api/sharing-url";
    public required string Token { get; init; }
}