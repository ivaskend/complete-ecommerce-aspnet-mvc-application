 using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinylesque.Data.Services;
using Vinylsque.Data;

namespace Vinylsque.Controllers
{
    public class VinylsController : Controller
    {
        private readonly IVinylsService _service;

        public VinylsController(IVinylsService service)
        {
            _service = service;

        }

        public async Task<IActionResult> Index()
        {
            var allVinyls = await _service.GetAllAsync(n => n.AlbumFormats);
            return View(allVinyls);
        }
        //GET: Vinyls/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var vinylDetail = await _service.GetVinylByIdAsync(id);
            return View(vinylDetail);
        }
        //GET: Vinyls/Create

        public IActionResult Create()
        {
            ViewData["Welcome"] = "Welcome to our store";
            ViewBag.Description = "This is the store description";
            return View();
        }
    }
}
