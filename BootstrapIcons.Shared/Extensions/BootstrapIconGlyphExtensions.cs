using System.Linq;
using System.Reflection;
using BootstrapIcons.Net.Attributes;

namespace BootstrapIcons.Net.Extensions
{
    public static class BootstrapIconGlyphExtensions
    {
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
            TypeInfo enumType = typeof(BootstrapIconGlyph).GetTypeInfo();
            MemberInfo[] memberInfos = enumType.GetMember(glyph.ToString());
            MemberInfo? enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType.AsType());
            SvgPathAttribute? svgPathAttribute = enumValueMemberInfo?.GetCustomAttribute<SvgPathAttribute>();
            if (svgPathAttribute is null) return false;
            path = svgPathAttribute.Path;
            width = svgPathAttribute.Width;
            height = svgPathAttribute.Height;
            return true;
        }
    }
}