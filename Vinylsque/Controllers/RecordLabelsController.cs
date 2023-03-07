using Microsoft.AspNetCore.Mvc;
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
    public class RecordLabelsController : Controller 
    {
        private readonly IRecordLabelsService _service;

       public RecordLabelsController(IRecordLabelsService service)
      {
        _service = service;

      }

    public async Task<IActionResult> Index()
        {
            var allRecordLabels = await _service.GetAllAsync();
            return View(allRecordLabels);
        }
        //GET: RecordLabel/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var recordLabelDetails = await _service.GetByIdAsync(id);
            if (recordLabelDetails == null) return View("NotFound");
            return View(recordLabelDetails);
        }

        //GET: recordlabels/create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, Bio")]RecordLabel recordLabel)
        {
            if (!ModelState.IsValid) return View(recordLabel);

            await _service.AddAsync(recordLabel);

            return RedirectToAction(nameof(Index));

        }
    }
}
