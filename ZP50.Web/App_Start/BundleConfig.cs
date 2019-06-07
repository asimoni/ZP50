using System.Web;
using System.Web.Optimization;

namespace ZP50.Web
{
    public class BundleConfig
    {
        // Per altre informazioni sulla creazione di bundle, vedere https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Utilizzare la versione di sviluppo di Modernizr per eseguire attività di sviluppo e formazione. Successivamente, quando si è
            // pronti per passare alla produzione, usare lo strumento di compilazione disponibile all'indirizzo https://modernizr.com per selezionare solo i test necessari.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/umd/popper.js", 
                      "~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/jsqrcode").Include(
                "~/Scripts/jsqrcode/grid.js",
                "~/Scripts/jsqrcode/version.js",
                "~/Scripts/jsqrcode/detector.js",
                "~/Scripts/jsqrcode/formatinf.js",
                "~/Scripts/jsqrcode/errorlevel.js",
                "~/Scripts/jsqrcode/bitmat.js",
                "~/Scripts/jsqrcode/datablock.js",
                "~/Scripts/jsqrcode/bmparser.js",
                "~/Scripts/jsqrcode/datamask.js",
                "~/Scripts/jsqrcode/rsdecoder.js",
                "~/Scripts/jsqrcode/gf256poly.js",
                "~/Scripts/jsqrcode/gf256.js",
                "~/Scripts/jsqrcode/decoder.js",
                "~/Scripts/jsqrcode/qrcode.js",
                "~/Scripts/jsqrcode/findpat.js",
                "~/Scripts/jsqrcode/alignpat.js",
                "~/Scripts/jsqrcode/databr.js"
                ));

            

              bundles.Add(new StyleBundle("~/Content/site-css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/line-awesome-font-awesome.min.css",
                      "~/Content/site.css"));
        }
    }
}
