using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CarShop.Infrastructure
{
    [HtmlTargetElement("img", Attributes = "alt-src")]
    public class SrcOrPlaceholder : TagHelper
    {
        public string AltSrc { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagHelperAttribute src;
            if (!output.Attributes.TryGetAttribute("src", out src))
            {
                output.Attributes.SetAttribute("src", AltSrc);
                return;
            }
            var template = src.Value.ToString()?.Replace("{num}", "1").Split('/')[1];
            DirectoryInfo dir = new DirectoryInfo(@"wwwroot\images");
            FileInfo[] filesInDir = dir.GetFiles("*" + template + "*.*");
            string extension = null;
            foreach (FileInfo foundFile in filesInDir)
            {
                extension = foundFile.Extension;
                break;
            }
            var hrefToImg = extension == null ? AltSrc : $"images/{template}{extension}";
            output.Attributes.SetAttribute("src", hrefToImg);
        }
    }
}
