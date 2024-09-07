using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.Market.Core.Services;

namespace Music.Market.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService musicService;

        public MusicController(IMusicService _musicService)
        {
            this.musicService = _musicService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Core.Models.Music>>> GetAllMusic()
        {
            var musics = await musicService.GetAllWithArtist();
            return Ok(musics);
        }
    }
}
