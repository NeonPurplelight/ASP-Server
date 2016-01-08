using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using aspserver_sfb.Models;
using System.Web.Http.OData.Builder;

namespace aspserver_sfb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Inserat>("Inserate");
            config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
            



        /*
        // Web-API-Konfiguration und -Dienste
        // Web-API für die ausschließliche Verwendung von Trägertokenauthentifizierung konfigurieren.
        config.SuppressDefaultHostAuthentication();
        config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

        // Web-API-Routen
        config.MapHttpAttributeRoutes();

        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
        */
    }
    }
}
