using System.Linq;
using System.Web.Http;

namespace FoodDelivery
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Address",
                routeTemplate: "api/Address/{action}/{id}",
                defaults: new { controller = "Address", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "Client",
                routeTemplate: "api/Client/{action}/{id}",
                defaults: new { controller = "Client", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "Food",
                routeTemplate: "api/Food/{action}/",
                defaults: new { controller = "Client" }
            );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

        }
    }
}
