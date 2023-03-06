using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinylesque.Data.Base;
using Vinylsque.Data;
using Vinylsque.Models;

namespace Vinylesque.Data.Services
{
    public class ArtistsService : EntityBaseRepository<Artist>, IArtistsService
    {
        public ArtistsService(AppDbContext context): base(context) { }
   
        
    }
}
