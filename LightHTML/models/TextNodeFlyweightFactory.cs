using System;
using System.Collections.Generic;

namespace LightHTML.Models
{
    public class TextNodeFlyweightFactory
    {
        private static TextNodeFlyweightFactory? _instance;
        private Dictionary<string, LightTextNode> _textNodes;

        private TextNodeFlyweightFactory()
        {
            _textNodes = new Dictionary<string, LightTextNode>();
        }

        public static TextNodeFlyweightFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TextNodeFlyweightFactory();
                }
                return _instance;
            }
        }

        public LightTextNode GetTextNode(string text)
        {
            if (text == null)
            {
                text = string.Empty;
            }

            if (!_textNodes.ContainsKey(text))
            {
                _textNodes[text] = new LightTextNode(text);
            }

            return _textNodes[text];
        }

        public int Count
        {
            get { return _textNodes.Count; }
        }

        public void Reset()
        {
            _textNodes.Clear();
        }
    }
}