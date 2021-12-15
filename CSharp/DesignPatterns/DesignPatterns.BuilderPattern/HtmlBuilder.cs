using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BuilderPattern
{
    public class HtmlBuilder
    {
        private readonly string rootName;

        public HtmlElement Root { get; set; } = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            Root.Name = rootName;
        }

        public void AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            Root.Children.Add(e);
        }

        public override string ToString()
        {
            return Root.ToString();
        }

        public void Clear()
        {
            Root = new HtmlElement() { Name = rootName };
        }
    }
}
