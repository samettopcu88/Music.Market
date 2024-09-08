using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.Market.Api.DTO;
using Music.Market.Api.Validations;
using Music.Market.Core.Models;
using Music.Market.Core.Services;

namespace Music.Market.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService artistService;
        readonly IMapper mapper;

        public ArtistController(IArtistService _artistService, IMapper _mapper)
        {
            this.artistService = _artistService;
            this.mapper = _mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ArtistDTO>>> GetAllArtists()
        {
            var artists = await artistService.GetAllArtists();
            var artistResources = mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistDTO>>(artists);
            return Ok(artistResources);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ArtistDTO>> GetArtistById(int id)
        {
            var artist = await artistService.GetArtistById(id);
            var artistResource = mapper.Map<Artist, ArtistDTO>(artist);
            return Ok(artistResource);
        }

        [HttpPost]

        public async Task<ActionResult<ArtistDTO>> CreateArtist([FromBody] SaveArtistDTO saveArtistResource)
        {
            var validator = new SaveArtistResourceValidator();
            var validationResult = await validator.ValidateAsync(saveArtistResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var artistToCreate = mapper.Map<SaveArtistDTO, Artist>(saveArtistResource);

            var newArtist = await artistService.CreateArtist(artistToCreate);

            var artist = await artistService.GetArtistById(newArtist.Id);

            var artistResource = mapper.Map<Artist, ArtistDTO>(artist);

            return Ok(artistResource);
        }


    }
}
