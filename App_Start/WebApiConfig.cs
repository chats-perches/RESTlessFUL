using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RestFul.App_Start
{
    public class WebApiConfig
    {
            public static void Register(HttpConfiguration config)
            {
                EnableCrossSiteRequests(config);
                AddRoutes(config);
            }

            private static void AddRoutes(HttpConfiguration config)
            {
                config.Routes.MapHttpRoute(
                    name: "Default",
                    routeTemplate: "api/{controller}/{action}",
                    defaults: new { controller = "", action = "Get" }
                );
            }

            private static void EnableCrossSiteRequests(HttpConfiguration config)
            {
                var cors = new EnableCorsAttribute(
                    origins: "*",
                    headers: "*",
                    methods: "*");

                config.EnableCors(cors);

            }
        }
    }
