using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Okta.AspNet;
using Owin;
using ZP50.Web.Models;

[assembly: OwinStartup(typeof(ZP50.Web.Startup))]

namespace ZP50.Web
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOktaMvc(new OktaMvcOptions()
            {
                OktaDomain = ConfigurationManager.AppSettings["okta:OktaDomain"],
                ClientId = ConfigurationManager.AppSettings["okta:ClientId"],
                ClientSecret = ConfigurationManager.AppSettings["okta:ClientSecret"],
                RedirectUri = ConfigurationManager.AppSettings["okta:RedirectUri"],
                PostLogoutRedirectUri = ConfigurationManager.AppSettings["okta:PostLogoutRedirectUri"],
                GetClaimsFromUserInfoEndpoint = true,
                Scope = new List<string> { "openid", "profile", "email" },
            });
        }
        //public void Configuration(IAppBuilder app)
        //{
        //    ConfigureAuth(app);
        //    createRolesandUsers();
        //}


        //// In this method we will create default User roles and Admin user for login   
        //private void createRolesandUsers()
        //{
        //    ApplicationDbContext context = new ApplicationDbContext();

        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        //    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


        //    // In Startup iam creating first Admin Role and creating a default Admin User    
        //    if (!roleManager.RoleExists("Admin"))
        //    {

        //        // first we create Admin rool   
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "Admin";
        //        roleManager.Create(role);

        //        //Here we create a Admin super user who will maintain the website                  
        //        var user = UserManager.FindByEmail("uebi70@gmail.com");

        //        //Add default User to Role Admin   

        //            var result1 = UserManager.AddToRole(user.Id, "Admin");

        //    }

        //    // creating Creating Manager role    
        //    if (!roleManager.RoleExists("RESPO"))
        //    {
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "RESPO";
        //        roleManager.Create(role);

        //    }

        //    // creating Creating Employee role    
        //    if (!roleManager.RoleExists("USER"))
        //    {
        //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //        role.Name = "USER";
        //        roleManager.Create(role);

        //    }
        //}

        //private void CreateUser()
        //{
        //    //var user = new ApplicationUser();
        //    //user.UserName = "shanu";
        //    //user.Email = "syedshanumcain@gmail.com";

        //    //string userPWD = "A@Z200711";

        //    //var chkUser = UserManager.Create(user, userPWD);

        //}
    }
}
