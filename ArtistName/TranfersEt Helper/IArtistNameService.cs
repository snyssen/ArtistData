using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistName.TranfersEt_Helper
{
   public interface IArtistNameService
    {
        Task<ArtistName> GetArtistNameAsync(string name);

    }
}
