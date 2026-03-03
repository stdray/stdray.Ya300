using AngleSharp.Dom;
using AngleSharp.Html.Parser;

namespace stdray.Ya300;

public class Ya300Parser
{
    public Ya300ParserResult Parse(string html)
    {
        var parser = new HtmlParser();
        var doc = parser.ParseDocument(html);
        var titleEl = doc.QuerySelector("h1.title");
        var longThesisEl = doc.QuerySelector(".summary-scroll-inner");
        var shortThesisEl = doc.QuerySelector("meta[property='og:description']");
        return new Ya300ParserResult(
            Title: titleEl?.Text() ?? string.Empty,
            ShortThesis: shortThesisEl?.GetAttribute("content") ?? string.Empty,
            LongThesis: longThesisEl?.Html() ?? string.Empty);
    }
}