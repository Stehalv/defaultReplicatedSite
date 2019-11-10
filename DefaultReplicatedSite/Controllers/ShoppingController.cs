using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MakoLibrary.Contracts;
using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.Services;

namespace DefaultReplicatedSite.Controllers
{

    [RoutePrefix("shop")]
    public class ShoppingController : Controller
    {
        private ItemService _itemService = new ItemService();
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
        // GET: Shopping
        public ActionResult Index()
        {
            var model = new TestObject();
            var shoppingCart = ShoppingCart;
            model.Items = _itemService.GetItems(new ItemRequest(OrderConfiguration));
            model.Cats = _itemService.GetWebCategories(new WebCategoryRequest());
            return View(model);
        }
        #region AjaxRequests
        public ActionResult AddItemToOrder(ShoppingCartItem item)
        {
            if(ShoppingCart.FlowType != CheckoutFlowType.Shopping)
            {
                PropertyBagService.Delete(ShoppingCart);
                ShoppingCart.FlowType = CheckoutFlowType.Shopping;
            }
            ShoppingCart.FlowType = CheckoutFlowType.Shopping;
            ShoppingCart.OrderItems.Add(item);
            PropertyBagService.Update(ShoppingCart);
            return new JsonNetResult(new
            {
                success = true
            });
        }

        [HttpPost]
        public ActionResult AddItemToutoOrder(ShoppingCartItem item)
        {
            if (ShoppingCart.FlowType != CheckoutFlowType.Shopping)
            {
                PropertyBagService.Delete(ShoppingCart);
                ShoppingCart.FlowType = CheckoutFlowType.Shopping;
            }
            ShoppingCart.AutoOrderItems.Add(item);
            PropertyBagService.Update(ShoppingCart);
            return new JsonNetResult(new
            {
                success = true
            });
        }
        #endregion
    }
}