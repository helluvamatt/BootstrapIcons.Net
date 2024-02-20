using BootstrapIcons.Net;
using BootstrapIcons.Net.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.IO;
using System.Text.Encodings.Web;

namespace BootstrapIcons.AspNetCore
{
    public static class BootstrapIconHtmlHelper
    {
        public static IHtmlContent BootstrapIcon(this IHtmlHelper htmlHelper, BootstrapIconGlyph glyph, string width, string height, object? htmlAttributes = null)
        {

            if (!glyph.GetSvg(out string? svgPath, out int viewBoxWidth, out int viewBoxHeight))
                return new StringHtmlContent("");

            TagBuilder builder = new("svg");
            
            builder.Attributes.Add("xmlns", "");
            builder.Attributes.Add("width", width);
            builder.Attributes.Add("height", height);
            builder.Attributes.Add("fill", "currentColor");
            builder.Attributes.Add("focusable", "false");
            builder.Attributes.Add("viewBox", $"0 0 {viewBoxWidth} {viewBoxHeight}");
            builder.InnerHtml.SetHtmlContent($"<path d=\"{svgPath}\" />");

            if(htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                foreach (var attribute in attributes)
                {
                    if(builder.Attributes.ContainsKey(attribute.Key))
                        builder.Attributes[attribute.Key] = attribute.Value.ToString();
                    else
                        builder.Attributes.Add(attribute.Key, attribute.Value.ToString());
                }
            }

            using (var writer = new StringWriter())
            {
                builder.WriteTo(writer, HtmlEncoder.Default);
                return new HtmlString(writer.ToString());
            }
        }
    }
}
