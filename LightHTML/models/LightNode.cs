using System;

namespace LightHTML.Models
{
    public abstract class LightNode
    {
        public abstract string RenderOuterHTML();
        public abstract int ChildCount { get; }
    }
}