using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtistName.TranfersEt_Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArtistName.Controllers
{

    [Authorize]
    [ApiController]
    [ApiExplorerSettings(GroupName = "artistnames")]
    [Produces("application/json")]
    [Route("api/v1/artistnames/")]
    public class ArtistNameController : ControllerBase
    {
        private readonly IArtistNameService _artistnameService;

        public ArtistNameController(IArtistNameService artistnameService)
        {
            _artistnameService = artistnameService ?? throw new ArgumentNullException(nameof(artistnameService));
            
        }

        
        [AllowAnonymous]
        [HttpGet("{artistName}", Name = "GetArtistNameAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ArtistName>> GetArtistNameAsync([FromRoute] string artistname)
        {
            var artist = await _artistnameService.GetArtistNameAsync(artistname);
            if (artist == null) return NotFound("Couldn't find any associated ArtistName");
            return Ok(artist);
        }

    }
}
