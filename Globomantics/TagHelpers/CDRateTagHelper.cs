using Globomantics.Core.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Globomantics.TagHelpers
{
    [HtmlTargetElement("cdrate")]
    public class CDRateTagHelper : TagHelper
    {
        private readonly IRateService _rateService;


        public string Title { get; set; }
        public string MeterPercentage { get; set; }
        public CDTermLength TermLength { get; set; }


        public CDRateTagHelper(IRateService rateService)
        {
            _rateService = rateService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var rate = _rateService.GetCDRateByTerm(TermLength);
            output.Content.SetHtmlContent(
                $@"<div class='meter'>
                    <p>{Title}</p>
                    <div class='progress'>
                       <div class='progress-bar bg-info' style='width: {MeterPercentage}%'>{rate}%</div>
                    </div>
                </div>"
                );
        }
    }
}
