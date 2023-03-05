using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinylsque.Data;

namespace Vinylsque.Controllers
{
    public class AlbumFormatsController : Controller
    {
        private readonly AppDbContext _context;

        public AlbumFormatsController(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
                var allAlbumFormats = await _context.AlbumFormats.ToListAsync();
                return View();
         }
        }
    }

