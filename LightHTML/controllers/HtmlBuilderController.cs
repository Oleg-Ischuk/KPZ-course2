using System;
using System.Linq;
using LightHTML.Models;

namespace LightHTML.Controllers
{
    public class HtmlBuilderController
    {
        public LightElementNode CreateHtmlDocumentWithoutFlyweight(string[] lines)
        {
            var document = new LightElementNode("html", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            
            var head = new LightElementNode("head", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            var title = new LightElementNode("title", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            title.AddChild(new LightTextNode("Romeo and Juliet"));
            head.AddChild(title);
            document.AddChild(head);
            
            var body = new LightElementNode("body", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            
            bool isFirstLine = true;
            
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                
                if (isFirstLine)
                {
                    // Перший рядок - h1
                    var h1 = new LightElementNode("h1", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
                    h1.AddChild(new LightTextNode(line.Trim()));
                    body.AddChild(h1);
                    isFirstLine = false;
                }
                else if (line.Length < 20)
                {
                    // Рядки з менше ніж 20 символами - h2
                    var h2 = new LightElementNode("h2", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
                    h2.AddChild(new LightTextNode(line.Trim()));
                    body.AddChild(h2);
                }
                else if (line.StartsWith(" ") || line.StartsWith("\t"))
                {
                    // Рядки, що починаються з пробілу - blockquote
                    var blockquote = new LightElementNode("blockquote", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
                    blockquote.AddChild(new LightTextNode(line.Trim()));
                    body.AddChild(blockquote);
                }
                else
                {
                    // Всі інші рядки - параграфи
                    var p = new LightElementNode("p", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
                    p.AddChild(new LightTextNode(line.Trim()));
                    body.AddChild(p);
                }
            }
            
            document.AddChild(body);
            return document;
        }
        
        // Створення HTML-документа з використанням патерну Легковаговик
        public LightElementNode CreateHtmlDocumentWithFlyweight(string[] lines)
        {
            // Скидаємо фабрику легковаговиків
            TextNodeFlyweightFactory.Instance.Reset();
            
            var document = new LightElementNode("html", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            
            var head = new LightElementNode("head", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            var title = new LightElementNode("title", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            title.AddChild(TextNodeFlyweightFactory.Instance.GetTextNode("Romeo and Juliet"));
            head.AddChild(title);
            document.AddChild(head);
            
            var body = new LightElementNode("body", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
            
            bool isFirstLine = true;
            
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                
                string trimmedLine = line.Trim();
                
                if (isFirstLine)
                {
                    // Перший рядок - h1
                    var h1 = new LightElementNode("h1", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
                    h1.AddChild(TextNodeFlyweightFactory.Instance.GetTextNode(trimmedLine));
                    body.AddChild(h1);
                    isFirstLine = false;
                }
                else if (line.Length < 20)
                {
                    // Рядки з менше ніж 20 символами - h2
                    var h2 = new LightElementNode("h2", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
                    h2.AddChild(TextNodeFlyweightFactory.Instance.GetTextNode(trimmedLine));
                    body.AddChild(h2);
                }
                else if (line.StartsWith(" ") || line.StartsWith("\t"))
                {
                    // Рядки, що починаються з пробілу - blockquote
                    var blockquote = new LightElementNode("blockquote", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
                    blockquote.AddChild(TextNodeFlyweightFactory.Instance.GetTextNode(trimmedLine));
                    body.AddChild(blockquote);
                }
                else
                {
                    // Всі інші рядки - параграфи
                    var p = new LightElementNode("p", LightElementNode.DisplayType.Block, LightElementNode.ClosingType.WithClosingTag);
                    p.AddChild(TextNodeFlyweightFactory.Instance.GetTextNode(trimmedLine));
                    body.AddChild(p);
                }
            }
            
            document.AddChild(body);
            return document;
        }
    }
}