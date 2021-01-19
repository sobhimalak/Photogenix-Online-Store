using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotographyOnlineStore.Core.Contracts;
using PhotographyOnlineStore.Core.Models;
using PhotographyOnlineStore.Core.ViewModels;
using System.Web;

namespace PhotographyOnlineStore.Services
{
    class ShoppingCartService : IShoppingCartService
    {
        IRepository<Product> productContext;
        IRepository<ShoppingCart> shoppingCartContext;

        public const string ShoppingCartSessionName = "eCommerceShoppingCart";  //  Reference Id for Cookie

        public ShoppingCartService(IRepository<Product> ProductContext, IRepository<ShoppingCart> ShoppingCartContext)
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
                    if (createIfNull)  // Do we need a ShoppingCart? (if yes, create one)
                    {
                        shoppingCart = CreateNewShoppingCart(httpContext);
                    }
                }
            }
            else
            {
                if (createIfNull)  // Do we need a ShoppingCart? (if yes, create one)
                {
                    shoppingCart = CreateNewShoppingCart(httpContext);
                }
            }

            return shoppingCart;

        }

        private ShoppingCart CreateNewShoppingCart(HttpContextBase httpContext)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCartContext.Insert(shoppingCart);
            shoppingCartContext.Commit();

            HttpCookie cookie = new HttpCookie(ShoppingCartSessionName);
            cookie.Value = shoppingCart.Id;  // Assign ShoppingCart ID to cookie
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);  // Send back the cookie to the client

            return shoppingCart;
        }

        public void AddToShoppingCart(HttpContextBase httpContext, string productId)  // Add item to ShoppingCart
        {
            ShoppingCart shoppingCart = GetShoppingCart(httpContext, true);
            ShoppingCartItem item = shoppingCart.ShoppingCartItems.FirstOrDefault(i => i.ProductId == productId);

            if (item == null)
            {
                item = new ShoppingCartItem()
                {
                    ShoppingCartId = shoppingCart.Id,
                    ProductId = productId,
                    Quantity = 1
                };

                shoppingCart.ShoppingCartItems.Add(item);
            }
            else
            {
                item.Quantity = item.Quantity + 1;
            }

            shoppingCartContext.Commit();
        }

        public void RemoveFromShoppingCart(HttpContextBase httpContext, string itemId)
        {
            ShoppingCart shoppingCart = GetShoppingCart(httpContext, true);
            ShoppingCartItem item = shoppingCart.ShoppingCartItems.FirstOrDefault(i => i.Id == itemId);

            if (item != null)
            {
                shoppingCart.ShoppingCartItems.Remove(item);
                shoppingCartContext.Commit();
            }
        }

        public List<ShoppingCartItemViewModel> GetShoppingCartItems(HttpContextBase httpContext)
        {
            ShoppingCart shoppingCart = GetShoppingCart(httpContext, false);

            if (shoppingCart != null)
            {
                var results = (from b in shoppingCart.ShoppingCartItems
                               join p in productContext.Collection() on b.ProductId equals p.Id
                               select new ShoppingCartItemViewModel()
                               {
                                   Id = b.Id,
                                   Quantity = b.Quantity,
                                   ProductName = p.Name,
                                   Image = p.Image,
                                   Price = p.Price
                               }
                              ).ToList();

                return results;
            }
            else
            {
                return new List<ShoppingCartItemViewModel>();
            }
        }

        public ShoppingCartSummaryViewModel GetShoppingCartSummary(HttpContextBase httpContext)
        {
            ShoppingCart shoppingCart = GetShoppingCart(httpContext, false);
            ShoppingCartSummaryViewModel model = new ShoppingCartSummaryViewModel(0, 0);
            if (shoppingCart != null)
            {
                int? shoppingCartCount = (from item in shoppingCart.ShoppingCartItems
                                    select item.Quantity).Sum();

                decimal? shoppingCartTotal = (from item in shoppingCart.ShoppingCartItems
                                        join p in productContext.Collection() on item.ProductId equals p.Id
                                        select item.Quantity * p.Price).Sum();

                model.ShoppingCartCount = shoppingCartCount ?? 0;
                model.ShoppingCartTotal = shoppingCartTotal ?? decimal.Zero;

                return model;
            }
            else
            {
                return model;
            }
        }
    }
}