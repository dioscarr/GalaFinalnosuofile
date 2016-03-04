using System.Web.Mvc;

namespace Gala_MVC_Project.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new {Controller="Home", action = "Index", id = UrlParameter.Optional }, namespaces: new string[] {"Gala_MVC_Project.Areas.Admin.Controllers" }
            );
        }
    }
}