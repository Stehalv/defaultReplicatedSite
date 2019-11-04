using DefaultReplicatedSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.ViewModels
{
    public class CheckoutViewModel
    {
        public CheckoutViewModel()
        {
            ShoppingCart = new CartViewModel();
            Address = new CheckoutAddress();
        }
        public CartViewModel ShoppingCart { get; set; }
        public IAddress Address { get; set; }
        public int EnrollerID { get; set; }
    }
}