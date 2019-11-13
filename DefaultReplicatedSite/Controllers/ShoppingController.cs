using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MakoLibrary.Contracts;
using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.Services;
using DefaultReplicatedSite.ViewModels;
using System.Linq;
using Common;

namespace DefaultReplicatedSite.Controllers
{

    [RoutePrefix("{webalias}/products")]
    public class ShoppingController : Controller
    {
        #region construction

        private ItemService _itemService = new ItemService();
        private CheckoutService _checkoutService = new CheckoutService();
        private ShoppingService _shoppingService = new ShoppingService();
        private IOrderConfiguration OrderConfiguration = new UnitedStatesMarket().Configurations.Order;
        private IOrderConfiguration AutoOrderConfiguration = new UnitedStatesMarket().Configurations.AutoOrder;
        private ShoppingCartPropertyBag _shoppingCart { get; set; }
        public ShoppingCartPropertyBag ShoppingCart
        {
            get
            {
                if(_shoppingCart == null)
                {
                    _shoppingCart = PropertyBagService.Get<ShoppingCartPropertyBag>(Settings.Company.CookieName + "_ShoppingCart");
                }
                return _shoppingCart;
            }
        }
        #endregion
        public ActionResult Index()
        {
            var model = _shoppingService.GetProductLines();
            return View(model);
        }
        [Route("{productline}")]
        public ActionResult ProductLine(string productline)
        {
            var model = _shoppingService.GetProductLine(productline);
            return View(model);
        }

        [Route("{productline}/{category}")]
        public ActionResult Category(string category)
        {
            var model = _shoppingService.GetCategory(category);
            model.Items = _itemService.GetItems(new ItemRequest { WebCaegoryID = model.WebCategoryID, Configuration = OrderConfiguration });
            return View(model);
        }

        [Route("{productline}/{category}/{itemcode}")]
        public ActionResult Product(string itemcode)
        {
            return View();
        }
        #region AjaxRequests
        [HttpPost]
        public ActionResult AddItemToOrder(ShoppingCartItem item)
        {
            if(ShoppingCart.FlowType != CheckoutFlowType.Shopping)
            {
                PropertyBagService.Delete(ShoppingCart);
            }
            ShoppingCart.FlowType = CheckoutFlowType.Shopping;
            ShoppingCart.OrderItems.Add(item);
            PropertyBagService.Update(ShoppingCart);
            return new JsonNetResult(new
            {
                success = true,
                itemId = item.ItemId,
                title = item.Title,
                count = ShoppingCart.OrderItems.Count()
            });
        }

        [HttpPost]
        public ActionResult AddItemToutoOrder(ShoppingCartItem item)
        {
            //Todo: add error handling when flow is not correct, need to return response with choice to user to delete propertybag or continue where they left
            if (ShoppingCart.FlowType != CheckoutFlowType.Shopping)
            {
                PropertyBagService.Delete(ShoppingCart);
            }
            ShoppingCart.FlowType = CheckoutFlowType.Shopping;
            ShoppingCart.AutoOrderItems.Add(item);
            PropertyBagService.Update(ShoppingCart);
            return new JsonNetResult(new
            {
                success = true
            });
        }
        [HttpPost]
        public ActionResult RemoveItemFromCart(int id, int type)
        {
            if(type == OrderTypes.Order)
            {
                ShoppingCart.OrderItems.Remove(id);
            }
            else
            {
                ShoppingCart.AutoOrderItems.Remove(id);
            }
            PropertyBagService.Update(ShoppingCart);
            var cart = _checkoutService.GetShoppingCart(OrderConfiguration, AutoOrderConfiguration);

            var total = (type == OrderTypes.Order) ? cart.Order.Total : cart.AutoOrder.Total;
            var subTotal = (type == OrderTypes.Order) ? cart.Order.SubTotal : cart.AutoOrder.SubTotal;
            return new JsonNetResult(new
            {
                success = true,
                total = total.ToString("C"),
                subtotal = subTotal.ToString("C")
            });
        }
        public ActionResult UpdateCartItem(int id, int type, decimal quantity)
        {
            if (type == OrderTypes.Order)
            {
                ShoppingCart.OrderItems.Update(id, quantity);
            }
            else
            {
                ShoppingCart.AutoOrderItems.Update(id, quantity);
            }
            PropertyBagService.Update(ShoppingCart);
            var cart = _checkoutService.GetShoppingCart(OrderConfiguration, AutoOrderConfiguration);
            decimal itemTotal = 0;
            if (type == OrderTypes.Order)
            {
                var item = cart.Order.Items.FirstOrDefault(c => c.ItemId == id);
                itemTotal = item.Quantity * item.ItemPrice.ItemPrice;
            }
            var total = (type == OrderTypes.Order) ? cart.Order.Total : cart.AutoOrder.Total;
            var subTotal = (type == OrderTypes.Order) ? cart.Order.SubTotal : cart.AutoOrder.SubTotal;
            return new JsonNetResult(new
            {
                success = true,
                itemTotal = itemTotal.ToString("C"),
                total = total.ToString("C"),
                subtotal = subTotal.ToString("C")
            });
        }
        #endregion
    }
}