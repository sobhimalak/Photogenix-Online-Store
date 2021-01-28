
using PhotographyOnlineStore.Core.ViewModels;
using System.Collections.Generic;
using System.Web;

namespace PhotographyOnlineStore.Core.Contracts
{
    public interface IShoppingCartService
    {
        void AddOneItem(HttpContextBase httpContext, string itemId);
        void ReduceOneItem(HttpContextBase httpContext, string itemId);
        void AddToShoppingCart(HttpContextBase httpContext, string productId);
        void RemoveFromShoppingCart(HttpContextBase httpContext, string itemId);
        List<ShoppingCartItemViewModel> GetShoppingCartItems(HttpContextBase httpContext);
        ShoppingCartSummaryViewModel GetShoppingCartSummary(HttpContextBase httpContext);
        void ClearShoppingCart(HttpContextBase httpContext);

    }
}
