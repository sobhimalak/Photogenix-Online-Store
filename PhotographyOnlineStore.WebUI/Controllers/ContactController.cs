using PhotographyOnlineStore.WebUI.Models;
using PhotoographyOnlineStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PhotographyOnlineStore.WebUI.Controllers
{
    public class ContactController : Controller
    {
        ApplicationDbContext context;

        public ContactController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Contact
        public ActionResult Index()
        {
            return View(context.Contacts.ToList());
        }

        public ActionResult Create()
        {
            return View(new Contact());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                context.Contacts.Add(model);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Profile()
        {
            return View(new Contact());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Profile(Contact model)
        {
            if (ModelState.IsValid)
            {
                context.Contacts.Add(model);
                await context.SaveChangesAsync();//Save data to sql database
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}