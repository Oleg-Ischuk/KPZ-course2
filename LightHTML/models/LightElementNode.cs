using System;
using System.Collections.Generic;
using System.Text;

namespace LightHTML.Models
{
    public class LightElementNode : LightNode
    {
        private string _tagName;
        private DisplayType _displayType;
        private ClosingType _closingType;
        private List<string> _cssClasses;
        private List<LightNode> _children;

        public enum DisplayType
        {
            Block,
            Inline
        }

        public enum ClosingType
        {
            SelfClosing,
            WithClosingTag
        }

        public LightElementNode(string tagName, DisplayType displayType, ClosingType closingType)
        {
            _tagName = tagName;
            _displayType = displayType;
            _closingType = closingType;
            _cssClasses = new List<string>();
            _children = new List<LightNode>();
        }

        public string TagName
        {
            get { return _tagName; }
        }

        public DisplayType Display
        {
            get { return _displayType; }
        }

        public ClosingType Closing
        {
            get { return _closingType; }
        }

        public override int ChildCount
        {
            get { return _children.Count; }
        }

        public void AddCssClass(string className)
        {
            if (!string.IsNullOrEmpty(className) && !_cssClasses.Contains(className))
            {
                _cssClasses.Add(className);
            }
        }

        public void RemoveCssClass(string className)
        {
            _cssClasses.Remove(className);
        }

        public void AddChild(LightNode child)
        {
            if (_closingType == ClosingType.SelfClosing)
            {
                throw new InvalidOperationException("Cannot add children to a self-closing element");
            }
            if (child != null)
            {
                _children.Add(child);
            }
        }

        public string RenderInnerHTML()
        {
            if (_closingType == ClosingType.SelfClosing)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var child in _children)
            {
                sb.Append(child.RenderOuterHTML());
            }
            return sb.ToString();
        }

        public override string RenderOuterHTML()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<");
            sb.Append(_tagName);

            if (_cssClasses.Count > 0)
            {
                sb.Append(" class=\"");
                sb.Append(string.Join(" ", _cssClasses));
                sb.Append("\"");
            }

            if (_closingType == ClosingType.SelfClosing)
            {
                sb.Append(" />");
                return sb.ToString();
            }

            sb.Append(">");
            sb.Append(RenderInnerHTML());
            sb.Append("</");
            sb.Append(_tagName);
            sb.Append(">");

            return sb.ToString();
        }
    }
}