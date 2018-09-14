using Globomantics.Core.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Globomantics.TagHelpers
{
    [HtmlTargetElement("a",Attributes ="active-url")]
    public class ActiveTafHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContext;
        public string ActiveUrl { get; set; }

        public ActiveTafHelper(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (_httpContext.HttpContext.Request.Path.ToString().ToLower().Contains(ActiveUrl.ToLower()))
            {
                var existingAttributes = output.Attributes["class"]?.Value;

                if (existingAttributes != null)
                    output.Attributes.SetAttribute("class", "active " + existingAttributes.ToString());
                else
                    output.Attributes.SetAttribute("class", "active");
            }
        }
    }
}
