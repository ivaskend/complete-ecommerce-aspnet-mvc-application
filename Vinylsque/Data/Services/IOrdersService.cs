using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinylesque.Models;

namespace Vinylesque.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
