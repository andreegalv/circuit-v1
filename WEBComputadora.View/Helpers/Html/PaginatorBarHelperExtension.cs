using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WEBComputadora.View.Helpers.Html
{
    public static class PaginatorBarHelperExtension
    {
        public static IHtmlString PaginatorBar(this HtmlHelper htmlHelper, int currentPage, int firstPage, int lastPage)
        {
            StringBuilder sb = new StringBuilder();
            int totalPaginationToShow = 5;

            sb.Append("<nav id='paginatorBar'>");
            sb.Append("<ul class='pagination small' style='margin:0'>");

            sb.Append("<li");
            if (firstPage == currentPage)
                sb.Append(" class='disabled'");

            sb.Append("><a href='#' data-to-page='" + firstPage.ToString() + "'><span>&laquo;</span></a></li>");

            int iteratorPage = 0;

            if ((currentPage - 2) <= firstPage)
            {
                iteratorPage = firstPage;
            }
            else if ((currentPage + 2) <= lastPage)
            {
                iteratorPage = currentPage - 2;
            }
            else
            {
                iteratorPage = lastPage - 4;
            }

            for (int i = 0; i < totalPaginationToShow; i++)
            {
                sb.Append("<li");
                if (iteratorPage == currentPage)
                    sb.Append(" class='active'");

                sb.Append("><a href='#' data-to-page='" + iteratorPage.ToString() + "'><span>" + iteratorPage.ToString() + "</span></a></li>");

                if (iteratorPage >= lastPage)
                    break;
                else
                    iteratorPage++;
            }

            sb.Append("<li");
            if (lastPage == currentPage)
                sb.Append(" class='disabled'");

            sb.Append("><a href='#' data-to-page='" + lastPage.ToString() + "'><span>&raquo;</span></a></li>");

            sb.Append("</ul>");
            sb.Append("</nav>");

            return new MvcHtmlString(sb.ToString());
        }
    }
}