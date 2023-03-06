using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinylesque.Data.Base;
using Vinylsque.Models;

namespace Vinylesque.Data.Services
{
    public interface IArtistsService: IEntityBaseRepository<Artist>
    {
    }
}
