using ArtistData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NameArtist.Helper
{
    public class ArtistNamesService : IArtistNamesService
    {
        private readonly ArtistContext _paraContext;
        private readonly ILogger<ArtistNamesService> _logger;

        public ArtistNamesService(ArtistContext paraContext, ILogger<ArtistNamesService> logger)
        {
            _paraContext = paraContext ?? throw new ArgumentNullException(nameof(paraContext));
            _logger = logger;
        }

        public async Task<ArtistName> GetArtistNameAsync(string name)
        {
            var artist = await _paraContext.Artists
                .AsNoTracking()
                .Include(a => a.Id)
                .Include(a =>a.Gid)
                .Include(a => a.Name)
                .Include(a => a.Sort_name)
                .Include(a => a.Begin_date_year)
                .Include(a =>a.Begin_date_month )
                .Include(a => a.Begin_date_day)
                .Include(a => a.End_date_year)
                .Include(a => a.End_date_month)
                .Include(a => a.End_date_day)
                .Include(a => a.Type)
                .Include(a => a.Area)
                .Include(a => a.Gender)
                .Include(a => a.Comment)
                .Include(a => a.Edits_pending)
                .Include(a => a.Last_updated)
                .Include(a => a.Ended)
                .Include(a => a.Begin_area)
                .Include(a => a.End_area)
                .Select(a => new ArtistName
                {
                    Id = a.Id,
                    Name = a.Name,
                    Sort_name = a.Sort_name,
                    Gid = a.Gid,
                    Begin_date_year = a.Begin_date_year,
                    Begin_date_month = a.Begin_date_month,
                    Begin_date_day = a.Begin_date_day,
                    Last_updated = a.Last_updated,
                    Ended = a.Ended,
                    Comment = a.Comment,

                })
                .FirstOrDefaultAsync(a => a.Name == name);

            _logger.LogInformation("TEST TEST TEST TEST TEST TEST TEST");

           

            return artist;
        }

    }
}
