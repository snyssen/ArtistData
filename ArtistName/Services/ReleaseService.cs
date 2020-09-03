using ArtistName.DTO;
using ArtistName.Services.Interfaces;
using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtistName.Services
{
    public class ReleaseService : IReleaseService
    {
        private readonly ArtistContext _paraContext;
        private readonly ILogger<ReleaseService> _logger;

        public ReleaseService(ArtistContext paraContext, ILogger<ReleaseService> logger)
        {
            _paraContext = paraContext ?? throw new ArgumentNullException(nameof(paraContext));
            _logger = logger;
        }

        public async Task<ReleaseDto> GetReleaseAsync(int id)
        {
            var release = await _paraContext.Releases
                .Select(r => new ReleaseDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    Gid = r.Gid,
                    Release_group = r.Release_group,
                    Packaging = (int)r.Packaging,
                    Artist_credit = r.Artist_credit,
                    Barcode = r.Barcode,
                    Language = (int)r.Language,
                    Quality = (int)r.Quality,
                    Script = (int)r.Script,
                    Status = (int)r.Status,
                    Edits_pending = (int)r.Edits_pending,
                    Comment = r.Comment,
                    Last_updated = r.Last_updated
                })
                .FirstOrDefaultAsync(r => r.Id == id);

            _logger.LogInformation("TEST TEST TEST TEST TEST TEST TEST");


            return release;
        }
    }
}
