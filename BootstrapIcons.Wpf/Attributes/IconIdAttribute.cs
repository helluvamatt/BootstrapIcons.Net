using System;

namespace BootstrapIcons.Wpf.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal sealed class IconIdAttribute : Attribute
    {
        public IconIdAttribute(string iconId)
        {
            IconId = iconId;
        }

        public string IconId { get; }
    }
}