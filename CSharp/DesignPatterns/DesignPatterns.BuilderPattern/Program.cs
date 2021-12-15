using System.Text;

namespace DesignPatterns.BuilderPattern;

public class Program
{
    public static void Main(string[] args)
    {
        // Too much low level details here
        // Higher level API is needed
        var hello = "Hello";

        var sb = new StringBuilder();

        sb.Append("<p>");
        sb.Append(hello);
        sb.Append("</p>");

        Console.WriteLine(sb);

        var words = new[] { "Hello", "World" };
        sb.Clear();
        sb.Append("<ul>");
        foreach (var word in words)
        {
            sb.Append($"<li>{word}</li>");
        }
        sb.Append("</ul>");

        Console.WriteLine(sb);

        Console.WriteLine("****");

        var builder = new HtmlBuilder("ul");

        builder.AddChild("li", "hello")
               .AddChild("li", "world");
        
        Console.WriteLine(builder);
    }
}