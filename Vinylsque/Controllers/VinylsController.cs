using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinylsque.Data;

namespace Vinylsque.Controllers
{
    public class VinylsController : Controller
    {
        private readonly AppDbContext _context;

        public VinylsController(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            var allVinyls = await _context.Vinyls.Include(n => n.AlbumFormats).OrderBy(n=> n.Name).ToListAsync();
            return View(allVinyls);
        }
    }
}
