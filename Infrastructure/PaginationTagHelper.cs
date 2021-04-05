using DallinCollinsBowlingLeague.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsBowlingLeague.Infrastructure
{
    //targets the div tag
    [HtmlTargetElement("div", Attributes = "page-info")]
    public class PaginationTagHelper : TagHelper
    {

        private IUrlHelperFactory urlInfo;

        //uses a IUrlHelperFactory to help with url information
        public PaginationTagHelper (IUrlHelperFactory uhf)
        {
            urlInfo = uhf;
        }

        //need to have at least one set up correctly
        public PageNumberingInfo PageInfo { get; set; }

        public string teamname { get; set; }

        //sets up a blank dictionary that has a key and value pair
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();


        //brings in viewcontext so we can use it in public override class
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        //properties to help with css of page selected
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }


        //need to have a process class when inheriting from the TagHelper class
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            IUrlHelper urlHelp = urlInfo.GetUrlHelper(ViewContext);

            //class used to build/render tags
            //builds a div tag
            TagBuilder finishedTag = new TagBuilder("div");

            //builds out an a tag for each page
            for (int i = 1; i <= PageInfo.NumPages; i++)
            {

                TagBuilder individualTag = new TagBuilder("a");

                //using key-value pair to populate the attributes
                KeyValuePairs["pageNum"] = i;



                
                individualTag.Attributes["href"] = urlHelp.Action("Index", KeyValuePairs);


                //highlights the current page number
                if (PageClassesEnabled)
                {
                    individualTag.AddCssClass(PageClass);

                    //if i is equal to PageModel.CurrentPage, then do PageClassSelected. Otherwise, do PageClassNormal
                    individualTag.AddCssClass(i == PageInfo.CurrentPage ? PageClassSelected : PageClassNormal);
                }


                //name associated with the above tag, appends this to the inner html, is what the user will see
                individualTag.InnerHtml.AppendHtml(i.ToString());

                //appends the a tag to the inside of the div tag
                finishedTag.InnerHtml.AppendHtml(individualTag);
            }
            output.Content.AppendHtml(finishedTag.InnerHtml);



        }


    }
}
