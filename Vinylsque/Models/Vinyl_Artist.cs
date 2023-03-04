using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vinylsque.Models
{
    public class Vinyl_Artist
    {
        public int VinylId { get; set; }
        public Vinyl Vinyl { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
