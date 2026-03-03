namespace stdray.Ya300.Tests;

public class Ya300ClientTests : BaseTests
{
    [Theory]
    [InlineData("https://300.ya.ru/3fOcYRBL", "https://habr.com/ru/news/729422")]
    public async Task ClientResponse_ShouldBeExpected(string expected, string url)
    {
        var uri = new Uri(url);
        var client = Resolve<Ya300Client>();
        var resp = await client.GetSummaryLink(uri);
        Assert.NotNull(resp);
        Assert.Equal(expected, resp.SharingUrl);
    }
}