
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotographyOnlineStore.Core.Models
{
    public class ShoppingCart : BaseEntity
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerTelephone { get; set; }
        public string BillingAddress { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart()
        {
            this.ShoppingCartItems = new List<ShoppingCartItem>();
        }
    }
}