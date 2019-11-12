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
        private ItemService _itemService = new ItemService();
        private CheckoutService _checkoutService = new CheckoutService();
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
        [Route("all")]
        public ActionResult Index()
        {
            var model = new WebCategoryViewModel
            {
                ChildCategories = new List<WebCategory>
                {
                    new WebCategory
                    {
                        Name = "Kristals Gemstone Skincare",
                        MediumImage = "https://i1.wp.com/luxxium.net/wp-content/uploads/2019/04/unnamed.jpg?w=760&amp;ssl=1",
                        WebCategoryId = 1,
                        Descr = "KRISTALS<br> GEMSTONE SKINCARE"
                    },
                    new WebCategory
                    {
                        Name = "TechTure advanced skincare techology",
                        MediumImage = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/04/TECH.png?w=760&amp;ssl=1",
                        WebCategoryId = 2,
                        Descr = "TECHTURE ADVANCED <br>SKINCARE TECHNOLOGY"
                    },
                }
            };
            return View(model);
        }
        [Route("category/{category}")]
        public ActionResult CategoryList(int category)
        {
            var model = new WebCategoryViewModel();
            model.ChildCategories = _itemService.GetWebCategories(new WebCategoryRequest()).Select(c => new WebCategory { 
                WebCategoryId = c.WebCategoryId,
                Descr = c.Descr,
                MediumImage = c.MediumImage
            }).ToList();
            return View(model);
        }

        [Route("{category}")]
        public ActionResult CategoryProductList(int category)
        {
            var model = new WebCategoryViewModel();
            model.Items = _itemService.GetItems(new ItemRequest(OrderConfiguration));
            return View(model);
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
                success = true
            });
        }

        [HttpPost]
        public ActionResult AddItemToutoOrder(ShoppingCartItem item)
        {
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