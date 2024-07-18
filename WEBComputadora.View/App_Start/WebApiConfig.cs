using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WEBComputadora.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var jsonFormatterOut = config.Formatters.JsonFormatter;
            jsonFormatterOut.SerializerSettings.PreserveReferencesHandling = 
                PreserveReferencesHandling.Objects;

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.MapHttpAttributeRoutes();
        }
    }
}