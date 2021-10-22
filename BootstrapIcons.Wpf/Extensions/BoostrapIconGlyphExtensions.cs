using System.Windows.Media;
using System.Windows.Shapes;
using BootstrapIcons.Net;
using BootstrapIcons.Net.Extensions;

namespace BootstrapIcons.Wpf.Extensions
{
    public static class BoostrapIconGlyphExtensions
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
    }
}