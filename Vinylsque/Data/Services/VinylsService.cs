using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinylesque.Data.Base;
using Vinylsque.Data;
using Vinylsque.Models;

namespace Vinylesque.Data.Services
{
    public class VinylsService:EntityBaseRepository<Vinyl>, IVinylsService
    {
        private readonly AppDbContext _context;

        public VinylsService(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<Vinyl> GetVinylByIdAsync(int id)
        {
            var vinylDetails = await _context.Vinyls
                .Include(af => af.AlbumFormats)
                .Include(rl => rl.RecordLabel)
                .Include(av => av.Vinyl_Artist).ThenInclude(a => a.Artist)
                .FirstOrDefaultAsync(n => n.Id == id);

            return  vinylDetails;
        }
    }
}
