using PhotographyOnlineStore.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyOnlineStore.Core.Models
{
    public interface IOrderService
    {
        void CreateOrder(Order baseOrder, List<ShoppingCartItemViewModel> shoppingCartItems);
    }
}
