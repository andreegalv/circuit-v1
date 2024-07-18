using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WEBComputadora.Model.Utils.Messages;

namespace WEBComputadora.View.Helpers.Html
{
    public static class AlertMessageHelperExtension
    {
        public static IHtmlString AlertMessage(this HtmlHelper htmlHelper, string message, AlertMessageType type, bool isClose = true)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<div class='alert alert-");
            switch (type)
            {
                case AlertMessageType.Info:
                    sb.Append("info");
                    break;
                case AlertMessageType.Warning:
                    sb.Append("warning");
                    break;
                case AlertMessageType.Success:
                    sb.Append("success");
                    break;
                case AlertMessageType.Error:
                    sb.Append("error");
                    break;
            };

            if (isClose)
            {
                sb.Append(" alert-dismissible");
            }

            sb.Append("' role='alert'>");

            if (isClose)
            {
                sb.Append("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>");
            }
            sb.Append(message);
            sb.Append("</div>");

            return new MvcHtmlString(sb.ToString());
        }
    }
}