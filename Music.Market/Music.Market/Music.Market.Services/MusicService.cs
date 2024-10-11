using Music.Market.Core;
using Music.Market.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Market.Services
{
    public class MusicService : IMusicService
    {
        private readonly IUnitOfWork unitOfWork;

        public MusicService(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }

        public async Task<Core.Models.Music> CreateMusic(Core.Models.Music newMusic)
        {
            await unitOfWork.Musics.AddAsync(newMusic);
            await unitOfWork.CommitAsync();
            //return new Core.Models.Music();
            return newMusic;
        }

        public async Task DeleteMusic(Core.Models.Music music)
        {
            unitOfWork.Musics.RemoveAsync(music);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Core.Models.Music>> GetAllWithArtist()
        {
            return await unitOfWork.Musics.GetAllWithArtistAsync();
        }

        public async Task<IEnumerable<Core.Models.Music>> GetMusicByArtistId(int artistId)
        {
            return await unitOfWork.Musics.GetAllWithArtistByArtistId(artistId);
        }


        public async Task<Core.Models.Music> GetMusicById(int id)
        {
            return await unitOfWork.Musics.GetByIdAsync(id);
        }

        public async Task UpdateMusic(Core.Models.Music musicToBeUpdated, Core.Models.Music music)
        {
            musicToBeUpdated.Name = music.Name;
            musicToBeUpdated.Artist = music.Artist;

            await unitOfWork.CommitAsync();
        }
    }
}