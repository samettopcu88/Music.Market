﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music.Market.Api.DTO;
using Music.Market.Api.Validations;
using Music.Market.Core.Services;

namespace Music.Market.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService musicService;
        private readonly IMapper mapper;

        public MusicController(IMusicService _musicService, IMapper mapper)
        {
            musicService = _musicService;
            mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Core.Models.Music>>> GetAllMusic()
        {
            var musics = await musicService.GetAllWithArtist();
            var musicResources = mapper.Map<IEnumerable<Core.Models.Music>, IEnumerable<MusicDTO>>(musics);
            return Ok(musicResources);
        }

        [HttpGet("{id}")]

        public async  Task<ActionResult<MusicDTO>>GetMusicById(int id)
        {
            var music = await musicService.GetMusicById(id);
            var musicResource = mapper.Map<Core.Models.Music, MusicDTO>(music);
            return Ok(musicResource);
        }

        [HttpPost]
        public async Task<ActionResult<MusicDTO>> CreateMusic([FromBody] SaveMusicDTO saveMusicResource)
        {
            var validator = new SaveMusicResourceValidator();
            var validationResult = await validator.ValidateAsync(saveMusicResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var musicToCreate = mapper.Map<SaveMusicDTO, Core.Models.Music>(saveMusicResource);

            var newMusic = await musicService.CreateMusic(musicToCreate);

            var music = await musicService.GetMusicById(newMusic.Id);

            var musicResource = mapper.Map<Core.Models.Music, MusicDTO>(music);

            return Ok(music);
        }

        [HttpDelete]
        public async Task<ActionResult<MusicDTO>> DeleteMusic(int id)
        {
            if (id == 0)
                return BadRequest();

            var music = await musicService.GetMusicById(id);

            if (music == null)
                return NotFound();

            await musicService.DeleteMusic(music);

            var musicResource = mapper.Map<Core.Models.Music, MusicDTO>(music);

            return Ok(musicResource);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<MusicDTO>> UpdateMusic(int id, [FromBody] SaveMusicDTO saveMusicResource)
        {
            var validator = new SaveMusicResourceValidator();
            var validationResult = await validator.ValidateAsync(saveMusicResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var musicToBeUpdate = await musicService.GetMusicById(id);

            if (musicToBeUpdate == null)
                return NotFound();

            var music = mapper.Map<SaveMusicDTO, Core.Models.Music>(saveMusicResource);

            await musicService.UpdateMusic(musicToBeUpdate, music);

            var updatedMusic = await musicService.GetMusicById(id);
            var updatedMusicResource = mapper.Map<Core.Models.Music, MusicDTO>(updatedMusic);

            return Ok(updatedMusicResource);
        }
    }
}
