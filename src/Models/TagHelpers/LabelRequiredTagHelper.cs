namespace TheMatrixAPI.Models.TagHelpers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.TagHelpers;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Threading.Tasks;

    [HtmlTargetElement("label", Attributes = "asp-for")]
    public class LabelRequiredTagHelper : LabelTagHelper
    {
        public LabelRequiredTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.ProcessAsync(context, output);

            if (For.Metadata.IsRequired)
            {
                var spanEl = new TagBuilder("span");
                spanEl.InnerHtml.Append("*");
                spanEl.AddCssClass("required");

                output.Content.AppendHtml(spanEl);
            }
        }
    }
}
