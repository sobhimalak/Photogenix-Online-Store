using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotographyOnlineStore.Core.ViewModels
{
    public class ShoppingCartItemViewModel
    {
        public string Id { get; set; }

        public int Quantity { get; set; }
        [DisplayName("Product")]
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }
       
    }
}