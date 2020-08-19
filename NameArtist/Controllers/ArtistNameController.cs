using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NameArtist.Helper;

namespace NameArtist.Controllers
{
    [Authorize]
    [ApiController]
    [ApiExplorerSettings(GroupName = "artistnames")]
    [Produces("application/json")]
    [Route("api/v1/artistnames/")]
    public class ArtistNameController : ControllerBase
    {

        private readonly IArtistNamesService _artistnamesService;

        public ArtistNameController(IArtistNamesService artistsService)
        {
            _artistnamesService = artistsService ?? throw new ArgumentNullException(nameof(artistsService));
            
        }
        [AllowAnonymous]
        [HttpGet("{artistName}", Name = "GetArtistNameAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ArtistName>> GetPilotAsync([FromRoute] string artistname)
        {
            var art = await _artistnamesService.GetArtistNameAsync(artistname);
            if (art == null) return NotFound("Couldn't find any associated ArtistName");
            return Ok(art);
        }
    }
}
