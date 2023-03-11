using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinylesque.Data.Cart;

namespace Vinylesque.Data.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}
