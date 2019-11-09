using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public enum CheckoutSteps
    {
        ShoppingCart = 1,
        Information = 2,
        Shipping = 3,
        Payment = 4,
        OrderCompleted = 5
    }
}