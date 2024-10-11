using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Market.Core.Services
{
    public interface IMusicService
    {
        Task<IEnumerable<Models.Music>> GetAllWithArtist();
        Task<Models.Music> GetMusicById(int id);
        Task<IEnumerable<Models.Music>>GetMusicByArtistId(int id);
        Task<Models.Music> CreateMusic(Models.Music newMusic);
        Task UpdateMusic(Models.Music musicToBeUpdated,Models.Music music);
        Task DeleteMusic(Models.Music music);

    }
}
