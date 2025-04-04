using System;

namespace LightHTML.Models
{
    public class LightTextNode : LightNode
    {
        private string _text;

        public LightTextNode(string text)
        {
            _text = text ?? string.Empty;
        }

        public string Text
        {
            get { return _text; }
            set { _text = value ?? string.Empty; }
        }

        public override string RenderOuterHTML()
        {
            return _text;
        }

        public override int ChildCount => 0;
    }
}