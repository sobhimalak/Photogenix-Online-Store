using PhotographyOnlineStore.Core.ViewModels;
using PhotoographyOnlineStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoographyOnlineStore.Core.Contracts
{
    public interface IOrderService
    {
        void CreateOrder(Order baseOrder, List<ShoppingCartItemViewModel> shoppingCartItems);
    }
}
