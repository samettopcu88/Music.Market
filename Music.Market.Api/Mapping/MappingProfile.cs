using AutoMapper;
using Music.Market.Api.DTO;
using Music.Market.Core.Models;

namespace Music.Market.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domian To Resource
            CreateMap<Core.Models.Music, MusicDTO>();
            CreateMap<Artist, ArtistDTO>();

            //Resource To Domain
            CreateMap<MusicDTO,Core.Models.Music >();
            CreateMap<ArtistDTO,Artist >();

            CreateMap<SaveMusicDTO, Core.Models.Music>();
            CreateMap<SaveArtistDTO, Artist>();
        }

        
    }
}
