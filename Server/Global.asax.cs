using MathHouse.Domain;
using MathHouse.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MathHouse.Server
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			CommonHelpers.ComputeMigrations(ImhDbContext.Get);
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		//protected void Application_BeginRequest()
		//{
		//	if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
		//	{
		//		Response.Headers.Add("Access-Control-Allow-Headers", "content-type");
		//		Response.Headers.Add("Access-Control-Allow-Origin", "*");
		//		Response.StatusCode = 200;
		//		Response.Flush();
		//	}
		//}
	}
}
