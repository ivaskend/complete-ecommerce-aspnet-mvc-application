using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinylesque.Data.Base;
using Vinylesque.Data.ViewModels;
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

        public async Task AddNewVinylAsync(NewVinyl data)
        {
            var newVinyl = new Vinyl()
            {
                Name = data.Name,
                Description = data.Description,
                Details = data.Details,
                Price = data.Price,
                ImageURL = data.ImageURL,
                AlbumFormatsId = data.AlbumFormatsId,
                VinylGenre = data.VinylGenre,
                RecordLabelId = data.RecordLabelId
            };
            await _context.Vinyls.AddAsync(newVinyl);
            await _context.SaveChangesAsync();
            

            //Add Artists

            foreach(var artistId in data.ArtistIds)
            {
                var newArtistVinyl = new Vinyl_Artist()
                {
                    VinylId = newVinyl.Id,
                    ArtistId = artistId
                };
                await _context.Vinyls_Artist.AddAsync(newArtistVinyl);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<NewVinylsDropdowns> GetNewVinylDropdownsValues()
        {
            var response = new NewVinylsDropdowns()
            {
                Artists = await _context.Artists.OrderBy(n => n.FullName).ToListAsync(),
                AlbumFormats = await _context.AlbumFormats.OrderBy(n => n.Name).ToListAsync(),
                RecordLabels = await _context.RecordLabels.OrderBy(n => n.FullName).ToListAsync()
            };
            return response;


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

        public async Task UpdateVinylAsync(NewVinyl data)
        {
            var dbVinyl = await _context.Vinyls.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbVinyl != null)
            {
                dbVinyl.Name = data.Name;
                dbVinyl.Description = data.Description;
                dbVinyl.Details = data.Details;
                dbVinyl.Price = data.Price;
                dbVinyl.ImageURL = data.ImageURL;
                dbVinyl.AlbumFormatsId = data.AlbumFormatsId;
                dbVinyl.VinylGenre = data.VinylGenre;
                dbVinyl.RecordLabelId = data.RecordLabelId;   
                await _context.SaveChangesAsync();
             }

            //Remove existing artists
            var existingArtistsDb = _context.Vinyls_Artist.Where(n => n.VinylId == data.Id).ToList();
            _context.Vinyls_Artist.RemoveRange(existingArtistsDb);
            await _context.SaveChangesAsync();
            //Add Artists

            foreach (var artistId in data.ArtistIds)
            {
                var newArtistVinyl = new Vinyl_Artist()
                {
                    VinylId = data.Id,
                    ArtistId = artistId
                };
                await _context.Vinyls_Artist.AddAsync(newArtistVinyl);
            }
            await _context.SaveChangesAsync();
        
    }
    }
}
