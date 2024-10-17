using BootstrapIcons.Net;
using BootstrapIcons.Net.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BootstrapIcons.AspNetCore
{
    [HtmlTargetElement("svg", Attributes = "bootstrap-icon")]
    public class BootstrapIconTagHelper : TagHelper
    {
        public BootstrapIconGlyph BootstrapIcon { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (output.TagName?.ToLower() != "svg") return;

            output.Attributes.RemoveAll("bootstrap-icon");

            if (!BootstrapIcon.GetSvg(out string? svgPath, out int width, out int height))
            {
                output.SuppressOutput();
                return;
            }

            if (!output.Attributes.ContainsName("width"))
            {
                output.Attributes.SetAttribute("width", "1em");
            }
    
            if (!output.Attributes.ContainsName("height"))
            {
                output.Attributes.SetAttribute("height", "1em");
            }
        
            output.Attributes.SetAttribute("xmlns", "");
            output.Attributes.SetAttribute("fill", "currentColor");
            output.Attributes.SetAttribute("focusable", "false");
            output.Attributes.SetAttribute("viewBox", $"0 0 {width} {height}");
            output.Content.SetHtmlContent($"<path d=\"{svgPath}\" />");
        }
    }
}
