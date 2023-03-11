using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vinylsque.Models;

namespace Vinylesque.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Vinyl Vinyl { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
