using Music.Market.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Market.Core.Repositories
{
    public interface IMusicRepository : IRepository<Models.Music>
    {
        Task<IEnumerable<Models.Music>> GetAllWithArtistAsync();
        Task<Models.Music> GetWithArtistByIdAsync(int id);

        Task<IEnumerable<Models.Music>> GetAllWithArtistByArtistId(int artistId);
    }
}
