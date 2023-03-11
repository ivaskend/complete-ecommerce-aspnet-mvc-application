using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinylesque.Data.Cart;
using Vinylesque.Data.Services;
using Vinylesque.Data.ViewModels;

namespace Vinylesque.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IVinylsService _vinylsService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        public OrdersController(IVinylsService vinylsService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _vinylsService = vinylsService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }
        public async Task<IActionResult> Index()
        {
            string userId = "";
            var orders = await _ordersService.GetOrdersByUserIdAsync(userId);

            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }
        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var item = await _vinylsService.GetVinylByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _vinylsService.GetVinylByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAddress = "";

            await  _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}
