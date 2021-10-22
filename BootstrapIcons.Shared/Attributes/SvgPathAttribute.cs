using System;

namespace BootstrapIcons.Net.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal sealed class SvgPathAttribute : Attribute
    {
        public SvgPathAttribute(int width, int height, string path)
        {
            Width = width;
            Height = height;
            Path = path;
        }

        public int Width { get; }
        public int Height { get; }
        public string Path { get; }
    }
}