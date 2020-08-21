using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using ArtistName.Services.Interfaces;
using ArtistName.DTO;

namespace ArtistName.Services
{
    public class ArtistNameService : IArtistNameService
    {
        private readonly ArtistContext _paraContext;
        private readonly ILogger<ArtistNameService> _logger;

        public ArtistNameService(ArtistContext paraContext, ILogger<ArtistNameService> logger)
        {
            _paraContext = paraContext ?? throw new ArgumentNullException(nameof(paraContext));
            _logger = logger;
        }

        public async Task<ArtistNameDto> GetArtistNameAsync(string name)
        {
            var artist = await _paraContext.Artists
                .Select(a => new ArtistNameDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Sort_name = a.Sort_name,
                    Gid = a.Gid,
                    Gender = a.Gender,
                    Type = a.Type,
                    Comment = a.Comment,
                    Last_updated = a.Last_updated
                })
                .FirstOrDefaultAsync(a => a.Name == name);

            _logger.LogInformation("TEST TEST TEST TEST TEST TEST TEST");

            
            return artist;
        }
    }
}



