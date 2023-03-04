using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Vinylsque.Data;

namespace Vinylsque.Models
{
    public class Vinyl
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public string Details { get; set; }
        public VinylGenre VinylGenre { get; set; }

        //Relationships

        public List<Vinyl_Artist> Artists_Vinyl { get; set; }

        //AlbumFormats
        public int AlbumFormatsId { get; set; }
        [ForeignKey("AlbumFormatsId")]
        public AlbumFormats AlbumFormats { get; set; }

        //RecordLabel
        public int RecordLabelId { get; set; }
        [ForeignKey("RecordLabelId")]
        public RecordLabel RecordLabel { get; set; }





    }
}
