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

        [Route("{productline}/{category}/{itemid}")]
        public ActionResult Product(string itemid)
        {
            var item = _itemService.GetItems(new ItemRequest { Configuration = OrderConfiguration, SingleItemRequest = true, ItemId = itemid.ToString() }).FirstOrDefault();
            return View(item);
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
                title = item.ItemDescription,
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
        #endregion
    }
}