#region 

using System.Web.Optimization;

#endregion

namespace PhoneContact
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                        "~/Scripts/umd/popper.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/employee").Include(
                                "~/Scripts/custom/baseHelper.js",
                                "~/Scripts/custom/baseRequest.js",
                                "~/Scripts/custom/employee.js"));

            bundles.Add(new ScriptBundle("~/bundles/user").Include(
                                "~/Scripts/custom/baseHelper.js",
                                "~/Scripts/custom/baseRequest.js",
                                "~/Scripts/custom/user.js"));

            bundles.Add(new ScriptBundle("~/bundles/department").Include(
                                "~/Scripts/custom/baseHelper.js",
                                "~/Scripts/custom/baseRequest.js",
                                "~/Scripts/custom/department.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                                "~/Content/font-awesome.css",
                                "~/Content/bootstrap.css",
                                "~/Content/site.css"));

#if !DEBUG
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}