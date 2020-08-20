using ArtistData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistName.TranfersEt_Helper
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

        public async Task<ArtistName> GetArtistNameAsync(string name)
        {
            var artist = await _paraContext.Artists
                .AsNoTracking()
                .Include(a => a.Id)
                .Include(a => a.Name)
                .Include(a => a.Sort_name)
                .Include(a => a.Gid)
                .Include(a => a.Type)
                .Include(a => a.Gender)
                .Include(a => a.Comment)
                .Include(a => a.Last_updated)
                .ThenInclude(at => at.HasValue)
                .Select(a => new ArtistName
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



