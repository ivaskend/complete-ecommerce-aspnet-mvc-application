using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vinylsque.Models
{
    public class AlbumFormats
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "AlbumFormats")]
        public string Name { get; set; }

        //Relationships
        public List<Vinyl> Vinyls { get; set; }

    }
}
