using PhotographyOnlineStore.Core.Contracts;
using PhotographyOnlineStore.Core.Models;
using PhotographyOnlineStore.Core.ViewModels;
using PhotographyOnlineStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PhotographyOnlineStore.WebUI.Controllers
{
    public class ContactsController : Controller
    {
        IRepository<Contacts> context;

        public ContactsController(IRepository<Contacts> ContactsContext)
        {
            context = ContactsContext;
            
        }

       

        // GET: Contact
        public ActionResult Index()
        {
            List<Contacts> Contact = context.Collection().ToList();
            return View(Contact);
            //return View(context.contact.ToList());
        }

        public ActionResult Create()
        {
            ContactsViewModel viewModel = new ContactsViewModel();

            viewModel.Contacts = new Contacts();
           

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Contacts Contact)
        {
            if (!ModelState.IsValid)
            {
                
                return View(Contact);
            }
            else
            {
                
                context.Insert(Contact);
                context.Commit();
                
                return RedirectToAction("Index");
            }
        }


    }
}
