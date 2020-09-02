using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ArtistName.DTO;
using ArtistName.Services;
using ArtistName.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArtistName.Controllers
{

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
        [HttpGet("search", Name = "GetArtistNameAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ArtistNameDto>> GetArtistNameAsync([FromQuery] string search)
        {
                string searchDecoded = HttpUtility.UrlDecode(search);
                string[] artists = searchDecoded.Split(",");
            List<ArtistNameDto> results = new List<ArtistNameDto>();
            foreach (string item in artists)
            {
                var result =  await _artistnameService.GetArtistNameAsync(item);
                results.Add(result);
            }
            return Ok(results);

        }

    }
}
