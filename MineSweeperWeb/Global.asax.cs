using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;

namespace MineSweeperWeb
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {

            GlobalConfiguration.Configure(config =>
            {
                //config.MapHttpAttributeRoutes();
                //config.Routes.MapHttpRoute(
                //    name: "Sample",
                //    routeTemplate: "api/{controller}/{id}",
                //    defaults: new { id = RouteParameter.Optional }
                //);
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                name: "ControllersApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                    );


                var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
                config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
                config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));


                IAssembliesResolver assembliesResolver = config.Services.GetAssembliesResolver();

                ICollection<Assembly> assemblies = assembliesResolver.GetAssemblies();

                StringBuilder errorsBuilder = new StringBuilder();

                foreach (Assembly assembly in assemblies)
                {
                    Type[] exportedTypes = null;
                    if (assembly == null || assembly.IsDynamic)
                    {
                        // can't call GetExportedTypes on a dynamic assembly
                        continue;
                    }

                    try
                    {
                        exportedTypes = assembly.GetExportedTypes();
                    }
                    catch (ReflectionTypeLoadException ex)
                    {
                        exportedTypes = ex.Types;
                    }
                    catch (Exception ex)
                    {
                        errorsBuilder.AppendLine(ex.ToString());
                    }
                }

                if (errorsBuilder.Length > 0)
                {
                    //Log errors into Event Log
                    Trace.TraceError(errorsBuilder.ToString());
                }
            });
        }
    }
}