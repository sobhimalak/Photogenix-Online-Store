using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotographyOnlineStore.WebUI.Controllers
{
    //By putting auth decorator you are going to be promted to log in when you click admin in the navbar.
    //[Authorize]
    //We can also allow a specific user like this: [Authorize (Users = "admin@yourdomain.com")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}


