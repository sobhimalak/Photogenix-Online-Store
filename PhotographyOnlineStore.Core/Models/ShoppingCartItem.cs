using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotographyOnlineStore.Core.Models
{
    public class ShoppingCartItem : BaseEntity
    {
 /*       
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerTelephone { get; set; }
        public string BillingAddress { get; set; }
*/ 
        public string ShoppingCartId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}