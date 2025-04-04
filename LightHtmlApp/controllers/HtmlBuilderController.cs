using System;
using LightHTML.Models;

namespace LightHTML.Controllers
{
    public class HtmlBuilderController
    {
        public void AddTableRow(LightElementNode tbody, string id, string name, string email)
        {
            var tr = new LightElementNode("tr", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            
            var tdId = new LightElementNode("td", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            tdId.AddChild(new LightTextNode(id));
            tr.AddChild(tdId);
            
            var tdName = new LightElementNode("td", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            tdName.AddChild(new LightTextNode(name));
            tr.AddChild(tdName);
            
            var tdEmail = new LightElementNode("td", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            tdEmail.AddChild(new LightTextNode(email));
            tr.AddChild(tdEmail);
            
            tbody.AddChild(tr);
        }

        public LightElementNode CreateTableHeader(params string[] columnNames)
        {
            var thead = new LightElementNode("thead", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            var headerRow = new LightElementNode("tr", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            
            foreach (var header in columnNames)
            {
                var th = new LightElementNode("th", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
                th.AddChild(new LightTextNode(header));
                headerRow.AddChild(th);
            }
            
            thead.AddChild(headerRow);
            return thead;
        }

        public LightElementNode CreateListItem(string text, bool addNestedContent = false)
        {
            var li = new LightElementNode("li", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            li.AddChild(new LightTextNode(text));
            
            if (addNestedContent)
            {
                var span = new LightElementNode("span", LightElementNode.DisplayType.Inline, LightElementNode.ClosingType.WithClosingTag);
                span.AddCssClass("highlight");
                span.AddChild(new LightTextNode(" (highlighted)"));
                li.AddChild(span);
            }
            
            return li;
        }
    }
}