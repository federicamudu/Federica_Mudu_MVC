using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AcademyF.TestWeek7.MVC.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string ToUser { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Content.SetContent("Mandami una e-mail");
            output.Attributes.SetAttribute("class", "btn btn-primary");
            output.Attributes.SetAttribute("href", $"mailto:{ToUser}");
        }
    }
}
