 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinylesque.Data.Services;
using Vinylsque.Data;
using Vinylsque.Models;

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

        public async Task<IActionResult> Filter(string searchString)
        {
            var allVinyls = await _service.GetAllAsync(n => n.AlbumFormats);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allVinyls.Where(n => n.Name.Contains(searchString) ||
                n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index",allVinyls);
        }
        //GET: Vinyls/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var vinylDetail = await _service.GetVinylByIdAsync(id);
            return View(vinylDetail);
        }
        //GET: Vinyls/Create

        public async Task<IActionResult> Create()
        {
            var vinylDropdownData = await _service.GetNewVinylDropdownsValues();

            ViewBag.AlbumFormats = new SelectList(vinylDropdownData.AlbumFormats, "Id","Name");
            ViewBag.RecordLabels = new SelectList(vinylDropdownData.RecordLabels, "Id", "FullName");
            ViewBag.Artists = new SelectList(vinylDropdownData.Artists, "Id", "FullName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewVinyl vinyl)
        {
            if (!ModelState.IsValid)
            {
                var vinylDropdownData = await _service.GetNewVinylDropdownsValues();

                ViewBag.AlbumFormats = new SelectList(vinylDropdownData.AlbumFormats, "Id", "Name");
                ViewBag.RecordLabels = new SelectList(vinylDropdownData.RecordLabels, "Id", "FullName");
                ViewBag.Artists = new SelectList(vinylDropdownData.Artists, "Id", "FullName");

                return View(vinyl);
            }
            await _service.AddNewVinylAsync(vinyl);
            return RedirectToAction(nameof(Index));
        }

        //GET: Vinyls/Edit/1

        public async Task<IActionResult> Edit(int id)
        {
            var vinylDetails = await _service.GetVinylByIdAsync(id);
            if (vinylDetails == null) return View("NotFound");

            var response = new NewVinyl()
            {
                Id = vinylDetails.Id,
                Name = vinylDetails.Name,
                Details = vinylDetails.Details,
                Description = vinylDetails.Description,
                Price = vinylDetails.Price,
                ImageURL = vinylDetails.ImageURL,
                VinylGenre = vinylDetails.VinylGenre,
                AlbumFormatsId = vinylDetails.AlbumFormatsId,
                RecordLabelId = vinylDetails.RecordLabelId,
                ArtistIds = vinylDetails.Vinyl_Artist.Select(n => n.ArtistId).ToList(),
            };

            var vinylDropdownData = await _service.GetNewVinylDropdownsValues();
            ViewBag.AlbumFormats = new SelectList(vinylDropdownData.AlbumFormats, "Id", "Name");
            ViewBag.RecordLabels = new SelectList(vinylDropdownData.RecordLabels, "Id", "FullName");
            ViewBag.Artists = new SelectList(vinylDropdownData.Artists, "Id", "FullName");

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewVinyl vinyl)
        {
            if (id != vinyl.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var vinylDropdownData = await _service.GetNewVinylDropdownsValues();

                ViewBag.AlbumFormats = new SelectList(vinylDropdownData.AlbumFormats, "Id", "Name");
                ViewBag.RecordLabels = new SelectList(vinylDropdownData.RecordLabels, "Id", "FullName");
                ViewBag.Artists = new SelectList(vinylDropdownData.Artists, "Id", "FullName");

                return View(vinyl);
            }
            await _service.UpdateVinylAsync(vinyl);
            return RedirectToAction(nameof(Index));
        }

    }

}
    

