using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PersonelBilgi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API yapılandırması ve hizmetler

            // Web API yolları
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "" +
                "_api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html")); //JSON İÇİN DÜZENLEME YAPTIM!
            config.EnableCors(new EnableCorsAttribute("*", "*", "*")); //CORS İÇİN KODLARIMI YAZDIM
            // Bu örnekte, "*" parametresi ile birlikte verilen üç argüman, herhangi bir kaynaktan gelen istekleri kabul etmeye izin vermektedir. Bu şekilde yapılandırıldığında, API herhangi bir domain, herhangi bir yöntem (GET, POST vb.) ve herhangi bir özellik (origin, content-type vb.) için isteklere cevap verebilir.
        }
    }

}
