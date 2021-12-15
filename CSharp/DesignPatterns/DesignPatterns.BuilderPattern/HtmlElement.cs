﻿using System.Text;

namespace DesignPatterns.BuilderPattern;

public class HtmlElement
{
    public string Name { get; set; }
    public string Text { get; set; }
    public List<HtmlElement> Children { get; set; } = new List<HtmlElement>();

    private const int indentSize = 2;

    public HtmlElement()
    {

    }

    public HtmlElement(string name, string text)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Text = text ?? throw new ArgumentNullException(nameof(text));
    }

    private string ToStringImpl(int indent)
    {
        var sb = new StringBuilder();
        var i = new string(' ', indentSize * indent);
        
        sb.AppendLine($"{i}<{Name}>");
        
        if (!string.IsNullOrWhiteSpace(Text))
        {
            sb.Append(new string(' ', indentSize * (indent + 1)));
            sb.AppendLine(Text);
        }

        foreach (var child in Children)
        {
            sb.Append(child.ToStringImpl(indent + 1));
        }

        sb.AppendLine($"{i}</{Name}>");

        return sb.ToString();
    }

    public override string ToString()
    {
        return ToStringImpl(0);
    }
}
