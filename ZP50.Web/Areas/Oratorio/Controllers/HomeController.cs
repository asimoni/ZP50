using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZP50.Web.Areas.Oratorio.Controllers
{
    [Authorize]
    public abstract class BaseController: Controller
    {

    }

    public class HomeController : BaseController
    {
        // GET: Oratorio/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}