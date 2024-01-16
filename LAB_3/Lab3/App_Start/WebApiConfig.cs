using Lab3.Addition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Web.Mvc;

namespace Lab3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}.{type}",
                defaults: new { id = RouteParameter.Optional, type = RouteParameter.Optional }
            );

        }
    }
}
