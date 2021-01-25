using PhotographyOnlineStore.Core.Models;
using PhotographyOnlineStore.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PhotographyOnlineStore.Core.Contracts
{
    public interface ICheckoutService
    {
        void AddBillingInfoToShoppingCart(HttpContextBase httpContext, OrderInfo orderInfo);
        List<CheckoutViewModel> GetShoppingCartItems(HttpContextBase httpContext);
    }

}
