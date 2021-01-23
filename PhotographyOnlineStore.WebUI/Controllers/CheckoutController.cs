using PhotographyOnlineStore.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PhotographyOnlineStore.WebUI.Controllers
{
    public class CheckoutController : Controller
    {
        ICheckoutService shoppingCartService;

        public CheckoutController(ICheckoutService ShoppingCartService)
        {
            this.shoppingCartService = ShoppingCartService;
        }
        // GET: ShoppingCart2
        public ActionResult Index()
        {
            var model = shoppingCartService.GetShoppingCartItems(this.HttpContext);
            return View(model);
        }

    }
}

