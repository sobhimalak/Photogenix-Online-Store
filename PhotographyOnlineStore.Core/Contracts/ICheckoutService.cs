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
        List<CheckoutViewModel> GetShoppingCartItems(HttpContextBase httpContext);
    }

}
