using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vinylsque.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }


        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }


        //Relationships
        public List<Vinyl_Artist> Artists_Vinyl { get; set; }

    }
}
