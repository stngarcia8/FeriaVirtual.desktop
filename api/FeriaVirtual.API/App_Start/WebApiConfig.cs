﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FeriaVirtual.API.App_Start;

namespace FeriaVirtual.API {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            System.Net.Http.Formatting.JsonMediaTypeFormatter json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            config.EnableCors(new AccessPolicyCors());

        }
    }
}
