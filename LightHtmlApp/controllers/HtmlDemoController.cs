using System;
using LightHTML.Models;

namespace LightHTML.Controllers
{
    public class HtmlDemoController
    {
        private readonly HtmlBuilderController _builder;

        public HtmlDemoController()
        {
            _builder = new HtmlBuilderController();
        }

        public string CreateTableExample()
        {
            var table = new LightElementNode("table", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            table.AddCssClass("data-table");
            table.AddCssClass("striped");
            var thead = _builder.CreateTableHeader("ID", "Name", "Email");
            table.AddChild(thead);
            var tbody = new LightElementNode("tbody", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            _builder.AddTableRow(tbody, "1", "John Doe", "john@example.com");
            _builder.AddTableRow(tbody, "2", "Jane Smith", "jane@example.com");
            _builder.AddTableRow(tbody, "3", "Bob Johnson", "bob@example.com");
            
            table.AddChild(tbody);

            return table.RenderOuterHTML();
        }
        public string CreateListExample()
        {
            var ul = new LightElementNode("ul", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            ul.AddCssClass("feature-list");
            ul.AddChild(_builder.CreateListItem("First item"));
            ul.AddChild(_builder.CreateListItem("Second item"));
            ul.AddChild(_builder.CreateListItem("Third item with nested content", true));
            
            return ul.RenderOuterHTML();
        }
        public string CreateSelfClosingExample()
        {
            var img = new LightElementNode("img", LightElementNode.DisplayType.Inline, LightElementNode.ClosingType.SelfClosing);
            img.AddCssClass("responsive");
            return img.RenderOuterHTML();
        }
    }
}