using PhotographyOnlineStore.Core.Contracts;
using PhotographyOnlineStore.Core.Models;
using PhotographyOnlineStore.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PhotographyOnlineStore.Services
{
    public class CheckoutService : ICheckoutService
    {
        IRepository<Product> productContext;
        IRepository<ShoppingCart> shoppingCartContext;

        public const string ShoppingCartSessionName = "eCommerceShoppingCart";  //  Reference Id for Cookie

        public CheckoutService(IRepository<Product> ProductContext, IRepository<ShoppingCart> ShoppingCartContext)
        {
            this.shoppingCartContext = ShoppingCartContext;
            this.productContext = ProductContext;
        }

        private ShoppingCart GetShoppingCart(HttpContextBase httpContext, bool createIfNull)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(ShoppingCartSessionName);

            ShoppingCart shoppingCart = new ShoppingCart();

            if (cookie != null)  // User visited before
            {
                string shoppingCartId = cookie.Value;  // Get the cookie value
                if (!string.IsNullOrEmpty(shoppingCartId)) //  Check the value exists, possibly this a cookie with empty value
                {
                    // locate the shoppingCart with cookie value
                    shoppingCart = shoppingCartContext.Find(shoppingCartId);
                }
                else
                {
                    // Do nothing or show error
                }
            }
            else
            {
                    // Do nothing or show error
            }

            return shoppingCart;

        }


        public List<CheckoutViewModel> GetShoppingCartItems(HttpContextBase httpContext)
        {
            ShoppingCart shoppingCart = GetShoppingCart(httpContext, false);

            if (shoppingCart != null)
            {
                                var results = (from b in shoppingCart.ShoppingCartItems
                                               join p in productContext.Collection() on b.ProductId equals p.Id
                                               select new CheckoutViewModel()
                                               {
                                                   Id = b.Id,
                                                   Quantity = b.Quantity,
                                                   ProductName = p.Name,
                                                   Image = p.Image,
                                                   Price = p.Price
                                               }
                                              ).ToList();

                                return results;
                
                return new List<CheckoutViewModel>();
            }
            else
            {
                return new List<CheckoutViewModel>();
            }
        }


    }

}
