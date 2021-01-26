using PhotographyOnlineStore.Core.Contracts;
using PhotographyOnlineStore.Core.Models;
using PhotographyOnlineStore.Core.ViewModels;
using PhotographyOnlineStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LexShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;
        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            context = productContext;
            productCategories = productCategoryContext;
        }

        public ActionResult Index(string searchType = null, string searchValue = null)
        {
            List<Product> products = null;
            List<ProductCategory> categories = productCategories.Collection().ToList();

            if (searchValue == null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                if (searchType == "Product")
                {
                    products = context.Collection().Where(p => p.Name.Contains(searchValue)).ToList();
                }
                else if (searchType == "Catagory")
                {
                    products = context.Collection().Where(p => p.Category == searchValue).ToList();
                }

            }

            ProductListViewModel model = new ProductListViewModel();
            model.Products = products;
            model.ProductCategories = categories;

            //            System.Diagnostics.Debug.WriteLine("searchType: " + searchType + "searchValue: " + searchValue);
            return View(model);
        }

        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(Contact model)
        {
            //if (ModelState.IsValid)
            //{
            //    var mail = new MailMessage();
            //    mail.To.Add(new MailAddress(model.SenderEmail));
            //    mail.Subject = "Your Email Subject";
            //    mail.Body = string.Format("<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>", model.SenderName, mail.SenderEmail, model.Message);
            //    mail.IsBodyHtml = true;
            //    using (var smtp = new SmtpClient())
            //    {
            //        await smtp.SendMailAsync(mail);
            //        return RedirectToAction("SuccessMessage");
            //    }
            //}
            return View("SuccessMessage");
        }

        public ActionResult SuccessMessage()
        {
            return View();
        }

        
    }
}