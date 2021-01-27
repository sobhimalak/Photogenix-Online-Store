using PhotographyOnlineStore.Core.Contracts;
using PhotographyOnlineStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PhotographyOnlineStore.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        IShoppingCartService shoppingCartService;
        IOrderService orderService;


        public ShoppingCartController(IShoppingCartService ShoppingCartService, IOrderService OrderService)
        {
            this.shoppingCartService = ShoppingCartService;
            this.orderService = OrderService;
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
        public ActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            var basketItems = shoppingCartService.GetShoppingCartItems(this.HttpContext);
            order.OrderStatus = "Order Created";

            //TODO: process payment...

            order.OrderStatus = "Payment Processed";
            orderService.CreateOrder(order, basketItems);
            //clear the basket
            shoppingCartService.ClearShoppingCart(this.HttpContext);

            //And finally redirect the user to the thank you page with order id.
            return RedirectToAction("Thankyou", new { OrderId = order.Id });
        }
        //create view (partial view) for the thank you page. Template: Empty
        public ActionResult ThankYou(string OrderId)
        {
            ViewBag.OrderId = OrderId;
            return View();
        }

    }
}

