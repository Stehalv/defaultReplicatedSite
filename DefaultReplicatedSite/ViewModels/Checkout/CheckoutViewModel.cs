using DefaultReplicatedSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.ViewModels
{
    public class CheckoutViewModel
    {
        public CartViewModel ShoppingCart { get; set; }
        public CheckoutAddress Address { get; set; }
    }
}