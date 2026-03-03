namespace stdray.Ya300.Tests;

public class Ya300ParserTests : BaseTests
{
    [Theory, MemberData(nameof(ParseResult_ShouldBeExpected_Source))]
    public void ParseResult_ShouldBeExpected(string path, string title, string shortThesis, string longThesis)
    {
        var html = ReadText(path);
        var parser = Resolve<Ya300Parser>();
        var result = parser.Parse(html);
        Assert.NotNull(result);
        Assert.Contains(title, result.Title);
        Assert.Contains(shortThesis, result.ShortThesis);
        Assert.Contains(longThesis, result.LongThesis);
    }

    public static IEnumerable<object[]> ParseResult_ShouldBeExpected_Source()
    {
        yield return
        [
            "assets/3f0cYRBL.html",
            "«Яндекс Браузер» научили переводить с китайского язык",
            "Технология работает на YouTube и будет добавлена на Bilibili",
            "Планируется поддержка китайской видеоплатформы Bilibili"
        ];
    }
}