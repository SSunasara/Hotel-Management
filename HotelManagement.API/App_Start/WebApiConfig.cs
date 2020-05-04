using HotelManagement.API.AuthHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace HotelManagement.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            config.Filters.Add(new BasicAuthenticationAttribute());

            var matches = config.Formatters
                            .Where(f => f.SupportedMediaTypes
                                         .Where(m => m.MediaType.ToString() == "application/xml" ||
                                                     m.MediaType.ToString() == "text/xml")
                                         .Count() > 0)
                            .ToList();
            foreach (var match in matches)
                config.Formatters.Remove(match);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
