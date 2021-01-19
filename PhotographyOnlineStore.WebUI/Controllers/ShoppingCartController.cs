using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotographyOnlineStore.Core.Contracts;


namespace PhotographyOnlineStore.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        IShoppingCartService shoppingCartService;

        public ShoppingCartController(IShoppingCartService ShoppingCartService)
        {
            this.shoppingCartService = ShoppingCartService;
        }
        // GET: ShoppingCart2
        public ActionResult Index()
        {
            var model = shoppingCartService.GetShoppingCartItems(this.HttpContext);
            return View(model);
        }

        public ActionResult AddToShoppingCart(string Id)
        {
            shoppingCartService.AddToShoppingCart(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromShoppingCart(string Id)
        {
            shoppingCartService.RemoveFromShoppingCart(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public PartialViewResult ShoppingCartSummary()
        {
            var shoppingCartSummary = shoppingCartService.GetShoppingCartSummary(this.HttpContext);

            return PartialView(shoppingCartSummary);
        }
    }
}
