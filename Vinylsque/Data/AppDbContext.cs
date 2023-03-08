using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinylsque.Models;

namespace Vinylsque.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vinyl_Artist>().HasKey(av => new
            {
                av.ArtistId,
                av.VinylId
            });

            modelBuilder.Entity<Vinyl_Artist>().HasOne(v => v.Vinyl).WithMany(av => av.Vinyl_Artist).HasForeignKey(v =>
            v.VinylId);
            modelBuilder.Entity<Vinyl_Artist>().HasOne(v => v.Artist).WithMany(av => av.Artists_Vinyl).HasForeignKey(v =>
           v.ArtistId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Vinyl> Vinyls { get; set; }
        public DbSet<Vinyl_Artist> Vinyls_Artist { get; set; }
        public DbSet<AlbumFormats> AlbumFormats{ get; set; }
        public DbSet<RecordLabel> RecordLabels { get; set; }




    }
}

