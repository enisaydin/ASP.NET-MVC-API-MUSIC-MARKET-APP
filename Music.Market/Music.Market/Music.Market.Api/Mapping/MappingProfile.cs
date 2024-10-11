using AutoMapper;
using Music.Market.Api.DTO;
using Music.Market.Core.Models;

namespace Music.Market.Api.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            //Domain to Resource 
            CreateMap<Core.Models.Music, MusicDTO>();
            CreateMap<Artist,ArtistDTO>();

            //Resource to Domain
            CreateMap<MusicDTO,Core.Models.Music>();
            CreateMap<ArtistDTO, Artist>();

            CreateMap<SaveMusicDTO, Core.Models.Music>();
            CreateMap<SaveArtistDTO, Artist>();

        }
    }
}
