using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MathHouse.Server
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.EnableCors();
			config.MapHttpAttributeRoutes();
			config.Routes.MapHttpRoute(
					name: "DefaultApi",
					routeTemplate: "api/{controller}/{action}/{id}",
					defaults: new { id = RouteParameter.Optional }
			);

			var formatters = GlobalConfiguration.Configuration.Formatters;
			var jsonFormatter = formatters.JsonFormatter;
			var settings = jsonFormatter.SerializerSettings;
			settings.Formatting = Formatting.Indented;
			settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
		}
	}
}
