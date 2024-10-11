using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Music.Market.Api.DTO;
using Music.Market.Api.Validators;
using Music.Market.Core.Models;
using Music.Market.Core.Services;

namespace Music.Market.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ArtistController : Controller
    {
        private readonly IArtistService artistService;
        private readonly IMapper mapper;

        public ArtistController(IArtistService _artistService, IMapper _mapper)
        {
            this.artistService = _artistService;
            this.mapper = _mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistDTO>>> GetAllArtists()
        {
            var artists = await artistService.GetAllArtists();
            var artistsResource = mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistDTO>>(artists);
                return Ok(artistsResource);
        }
        [HttpGet("id")]
        public async Task<ActionResult<ArtistDTO>> GetArtistById(int id)
        {
            var artist = await artistService.GetArtistById(id);
            var artistResource = mapper.Map<Artist, ArtistDTO>(artist);
            return Ok(artistResource);

        }
        [HttpPost]
        public async Task<ActionResult<ArtistDTO>>CreateArtist([FromBody]SaveArtistDTO saveArtistResource)
        {
            var validator = new SaveArtistResourceValidator();
            var validationResult = await validator.ValidateAsync(saveArtistResource);
            if(!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var artistToCreate = mapper.Map<SaveArtistDTO, Artist>(saveArtistResource);

            var newArtist = await artistService.CreateArtist(artistToCreate);

            var artist = await artistService.GetArtistById(newArtist.Id);
            var artistResource = mapper.Map<Artist, ArtistDTO>(artist);
            return Ok(artistResource);
        }
        [HttpDelete]
        public async Task<ActionResult<ArtistDTO>> DeleteArtists(int id)
        {
            var artist = await artistService.GetArtistById(id);
            await artistService.DeleteArtists(artist);
            var artistResource = mapper.Map<Artist, ArtistDTO>(artist);

            return Ok(artistResource);
        }

        [HttpPut("id")]
        public async Task<ActionResult<ArtistDTO>> UpdateArtist(int id, [FromBody] SaveArtistDTO saveArtistResource)
        {
            var validator = new SaveArtistResourceValidator();
            var validationResult = await validator.ValidateAsync(saveArtistResource);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var artistToBeUpdated = await artistService.GetArtistById(id);
            if (artistToBeUpdated == null)
                return NotFound();

            var artist = mapper.Map<SaveArtistDTO, Artist>(saveArtistResource);
            await artistService.UpdateArtist(artistToBeUpdated, artist);

            var updatedArtist = await artistService.GetArtistById(id);
            var updatedArtistResource = mapper.Map<Artist, ArtistDTO>(updatedArtist);
            return Ok(updatedArtistResource);
        }
    }
}
