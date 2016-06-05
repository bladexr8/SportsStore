using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SportsStore.Infrastructure;

namespace SportsStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "OrdersRoute",
                routeTemplate: "nonrest/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // remove the XML Formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // custom dependency resolver
            config.DependencyResolver = new CustomResolver();

            // handle circular references between Order and Order Line
            GlobalConfiguration.Configuration.Formatters.JsonFormatter
                .SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }
    }
}
