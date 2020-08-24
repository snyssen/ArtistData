using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtistName.DTO;
using ArtistName.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtistName.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "release")]
    [Produces("application/json")]
    [Route("api/v1/release/")]
    public class ReleaseController : ControllerBase
    {
        private readonly IReleaseService _releaseService;

        public ReleaseController(IReleaseService releaseService)
        {
            _releaseService = releaseService ?? throw new ArgumentNullException(nameof(releaseService));

        }


        [AllowAnonymous]
        [HttpGet("{releaseId}", Name = "GetReleaseAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReleaseDto>> GetReleaseAsync([FromRoute] int releaseId)
        {
            var release = await _releaseService.GetReleaseAsync(releaseId);
            if (release == null) return NotFound("Couldn't find any associated Release");
            return Ok(release);
        }
    }
}
