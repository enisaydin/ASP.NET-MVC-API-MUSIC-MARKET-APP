using Microsoft.EntityFrameworkCore;
using Music.Market.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Market.Data.Repositories
{
    public class MusicRepository : Repository<Core.Models.Music>,IMusicRepository 
    {
        public MusicRepository(MusicMarketDbContext context) :base(context) 
        {

        }
        private MusicMarketDbContext MusicMarketDbContext { get{ return context as MusicMarketDbContext; } }

        public async Task<IEnumerable<Core.Models.Music>> GetAllWithArtistAsync()
        {
            return await MusicMarketDbContext.Musics
                .Include(x=>x.Artist)
                .ToListAsync();
        }

        public async Task<IEnumerable<Core.Models.Music>> GetAllWithArtistByArtistId(int artistId)
        {
            return await MusicMarketDbContext.Musics
               .Include(x => x.Artist)
               .Where(x => x.ArtistId == artistId)
               .ToListAsync();
        }

        public async Task<Core.Models.Music> GetWithArtistByIdAsync(int id)
        {
            return await MusicMarketDbContext.Musics
               .Include(x => x.Artist)
               .SingleOrDefaultAsync(x=>x.Id==id);
        }
    }
}
