using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NameArtist.Helper
{
   public interface IArtistNamesService
    {
        Task<ArtistName> GetArtistNameAsync(string name);

    }
}
