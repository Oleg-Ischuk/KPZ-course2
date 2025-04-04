using System;

namespace LightHTML.Models
{
    public class LightTextNode : LightNode
    {
        private string _text;

        public LightTextNode(string text)
        {
            _text = text;
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public override string RenderOuterHTML()
        {
            return _text;
        }
    }
}