using System.Web;
using System.Web.Optimization;

namespace MathHouse.Server
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
									"~/Scripts/Libs/jquery-1.10.2.min.js",
									"~/Scripts/Libs/bootstrap.min.js",
									"~/Scripts/Libs/angular.min.js",
									"~/Scripts/Libs/ui-bootstrap-tpls-0.12.1.min.js",
									"~/Scripts/Libs/ui-grid.min.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
								"~/Content/bootstrap.min.css",
								"~/Content/bootstrap-rtl.min.css",
								"~/Content/ui-grid.min.css",
								"~/Content/Site.css"));
			BundleTable.EnableOptimizations = false;
		}
	}
}
