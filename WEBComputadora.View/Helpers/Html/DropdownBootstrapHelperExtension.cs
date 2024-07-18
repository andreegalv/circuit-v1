using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WEBComputadora.View.Helpers.Html
{
    public static class DropdownBootstrapHelperExtension
    {
        public static IHtmlString DropdownRows(this HtmlHelper htmlHelper, string title, int current, int[] sizeCollection, bool wrapOnGroup = false)
        {
            StringBuilder sb = new StringBuilder();

            if (wrapOnGroup)
                sb.Append("<div class='btn-group' role='group'>");

            sb.Append("<div id='buttonChangeRows' class='dropdown'>");

            sb.Append("<button class='btn btn-default dropdown-toggle' type='button' data-toggle='dropdown'>");
            sb.Append(title);
            sb.Append("</button>");

            sb.Append("<ul class='dropdown-menu'>");

            for (int i = 0; i < sizeCollection.Length; i++)
            {
                sb.Append("<li");
                if (current == sizeCollection[i])
                    sb.Append(" class='disabled'");

                sb.Append(">");

                sb.Append("<a href='#' data-changerows-val='" + sizeCollection[i].ToString() + "'");

                if (current == sizeCollection[i])
                    sb.Append(" data-changerows-selected");

                sb.Append(">");

                if (sizeCollection[i] > 0)
                {
                    sb.Append(sizeCollection[i].ToString() + " lineas");
                }
                else 
                { 
                    sb.Append("Infinito"); 
                }

                sb.Append("</a></li>");
            }
            sb.Append("</ul>");
            sb.Append("</div>");

            if (wrapOnGroup)
                sb.Append("</div>");

            return new MvcHtmlString(sb.ToString());
        }
    }
}