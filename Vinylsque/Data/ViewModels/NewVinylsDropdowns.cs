using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinylsque.Models;

namespace Vinylesque.Data.ViewModels
{
    public class NewVinylsDropdowns
    {
        public NewVinylsDropdowns()
        {
            RecordLabels = new List<RecordLabel>();
            AlbumFormats = new List<AlbumFormats>();
            Artists = new List<Artist>();
        }
        public List<RecordLabel> RecordLabels { get; set; }
        public List<AlbumFormats> AlbumFormats { get; set; }
        public List<Artist> Artists { get; set; }

    }
}
