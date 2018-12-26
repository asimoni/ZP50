using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZP50.Web.Areas.Administration.Models;

namespace ZP50.Web.Areas.Administration.Controllers
{
    public class UtentiController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        public UtentiController()
        {

        }

        public UtentiController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ??  HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        // GET: Administration/Utenti
        public ActionResult Index()
        {
            var utenti = UserManager.Users.ToList();

            return View(utenti);
        }


        public async Task<ActionResult> EditRoles(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            var roles = RoleManager.Roles;
            var userRoles = user.Roles.Select(x => x.RoleId).ToArray();
            var model = new UserRolesModel
            {
                Id=user.Id,
                Email = user.Email,
                Roles = roles.Select(x => new RoleSelectionModel { RoleName = x.Name, Selected = userRoles.Contains(x.Id) }).ToArray()                
            };

            

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditRoles(UserRolesModel model)
        {
            var user = await UserManager.FindByIdAsync(model.Id);
            var currentRoles = await UserManager.GetRolesAsync(model.Id);
            var targetRoles = model.Roles.Where(x=> x.Selected).Select(x => x.RoleName).ToArray();
            var removeRoles = currentRoles.Except(targetRoles).ToArray();
            var addRoles = targetRoles.Except(currentRoles).ToArray();
            await UserManager.AddToRolesAsync(user.Id, addRoles);
            await UserManager.RemoveFromRolesAsync(user.Id, removeRoles);

            return View(model);
        }
    }


}