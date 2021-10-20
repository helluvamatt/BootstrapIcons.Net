using System;
using System.Linq;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Shapes;
using BootstrapIcons.Wpf.Attributes;

namespace BootstrapIcons.Wpf.Extensions
{
    public static class BootstrapIconGlyphExtensions
    {
        /// <summary>
        /// Create a <see cref="Path" /> from the <see cref="BootstrapIconGlyph" />
        /// </summary>
        /// <param name="glyph">The icon glyph</param>
        /// <param name="foregroundBrush">A brush to use for the icon fill</param>
        /// <returns>The <see cref="Path"/></returns>
        public static Path? CreatePath(this BootstrapIconGlyph glyph, Brush foregroundBrush)
        {
            if (glyph.GetSvg(out string? strPath, out int width, out int height))
            {
                return new Path
                {
                    Data = Geometry.Parse(strPath),
                    Width = width,
                    Height = height,
                    Fill = foregroundBrush
                };
            }
            return null;
        }

        /// <summary>
        /// Extract the SVG path, width, and height for the given glyph
        /// </summary>
        /// <param name="glyph">Glyph to inspect</param>
        /// <param name="path">SVG path of the glyph</param>
        /// <param name="width">Width of the glyph, typically 16</param>
        /// <param name="height">Height of the glyph, typically 16</param>
        /// <returns>True if the glyph exists and was read successfully, false otherwise</returns>
        public static bool GetSvg(this BootstrapIconGlyph glyph, out string? path, out int width, out int height)
        {
            path = null;
            width = -1;
            height = -1;
            Type enumType = typeof(BootstrapIconGlyph);
            MemberInfo[] memberInfos = enumType.GetMember(glyph.ToString());
            MemberInfo? enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            SvgPathAttribute? svgPathAttribute = enumValueMemberInfo?.GetCustomAttribute<SvgPathAttribute>();
            if (svgPathAttribute is null) return false;
            path = svgPathAttribute.Path;
            width = svgPathAttribute.Width;
            height = svgPathAttribute.Height;
            return true;
        }
    }
}