using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Vinylesque.Data.Base;
using Vinylsque.Data;

namespace Vinylsque.Models
{
    public class NewVinyl
    {   
        [Display(Name ="Vinyl name")]
        [Required(ErrorMessage ="Name is required")]
   
        public string Name { get; set; }
        [Display(Name = "Vinyl description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Display(Name = "Price in MKD")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Display(Name = "Vinyl poster")]
        [Required(ErrorMessage = "Vinyl poster is required")]
        public string ImageURL { get; set; }
        [Display(Name = "Details")]
        [Required(ErrorMessage = "Details is required")]
        public string Details { get; set; }
        [Display(Name = "Select a genre")]
        [Required(ErrorMessage = "Vinyl is required")]
        public VinylGenre VinylGenre { get; set; }

        //Relationships

        [Display(Name = "Select artist(s)")]
        [Required(ErrorMessage = "Vinyl artist(s) is required")]
        public List<int> ArtistIds { get; set; }

        //AlbumFormats
        [Display(Name = "Select an album format")]
        [Required(ErrorMessage = "An album format is required")]
        public int AlbumFormatsId { get; set; }
        //RecordLabel
        [Display(Name = "Select a Record Label")]
        [Required(ErrorMessage = "Record Label is required")]
        public int RecordLabelId { get; set; }


    }
}
