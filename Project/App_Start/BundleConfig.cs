using System.Web.Optimization;

namespace Project
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery/jquery-3.3.1.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/vue/vue.js"));

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                "~/Content/Reset.css",
                "~/Content/bootstrap/bootstrap.css",
                "~/Content/site.css"));
        }
    }
}
