using System.Web;
using System.Web.Optimization;

namespace BRConselho.Avaliacao.Web.Api
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/libs/runtime*",
                      "~/Scripts/libs/polyfills*",
                      "~/Scripts/libs/vendor*",
                      "~/Scripts/libs/main*"));
        }
    }
}
