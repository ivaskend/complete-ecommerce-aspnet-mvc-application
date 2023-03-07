using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vinylesque.Data.Base;

namespace Vinylsque.Models
{
    public class RecordLabel:IEntityBase
    { 
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage ="Profile Picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "FullName")]
        [Required(ErrorMessage = "FullName is required")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Full Name must be between 3 and 50 chars")]

        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]

        public string Bio { get; set; }

        //Relationships 
        public List<Vinyl> Vinyls { get; set; }
    }
}
