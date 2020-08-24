using ArtistName.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistName.Services.Interfaces
{
   public interface IReleaseService
    {
        Task<ReleaseDto> GetReleaseAsync(int id);
    }
}
