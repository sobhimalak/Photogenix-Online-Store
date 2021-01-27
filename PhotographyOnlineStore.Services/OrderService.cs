using PhotographyOnlineStore.Core.Contracts;
using PhotographyOnlineStore.Core.Models;
using PhotographyOnlineStore.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyOnlineStore.Services
{
    public class OrderService : IOrderService
    {
        IRepository<Order> orderContext;
        public OrderService(IRepository<Order> OrderContext)
        {
            this.orderContext = OrderContext;
        }

        public void CreateOrder(Order baseOrder, List<ShoppingCartItemViewModel> shoppingCartItems)
        {
            //iterate through our basket item and then add it to the baseOrder
            foreach (var item in shoppingCartItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    ProductId = item.Id,
                    image = item.Image,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity
                });
            }
            //Insert our base order and the save the changes
            orderContext.Insert(baseOrder);
            orderContext.Commit();
        }
    }
}
