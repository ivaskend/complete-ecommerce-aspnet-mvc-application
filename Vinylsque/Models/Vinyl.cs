using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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








    }
}
