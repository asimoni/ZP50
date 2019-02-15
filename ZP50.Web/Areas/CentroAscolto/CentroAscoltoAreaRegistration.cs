using System.Web.Mvc;

namespace ZP50.Web.Areas.CentroAscolto
{
    public class CentroAscoltoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CentroAscolto";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CentroAscolto_default",
                "CentroAscolto/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}