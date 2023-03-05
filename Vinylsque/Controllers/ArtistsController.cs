using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinylsque.Data;

namespace Vinylsque.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly AppDbContext _context;

        public ArtistsController(AppDbContext context)
        {
            _context = context;
                    
        }
        public IActionResult Index()
        {
            var data = _context.Artists.ToList();
            return View(data);
        }
    }
}
