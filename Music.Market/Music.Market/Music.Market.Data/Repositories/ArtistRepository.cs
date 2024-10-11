using Microsoft.EntityFrameworkCore;
using Music.Market.Core.Models;
using Music.Market.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Market.Data.Repositories
{
    public class ArtistRepository:Repository<Artist>,IArtistRepository
    {
        public ArtistRepository(MusicMarketDbContext context) : base (context) 
        {

        }
        private MusicMarketDbContext MusicMarketDbContext
        {
            get
            {
                return context as MusicMarketDbContext;
            }
        }

        public async Task<IEnumerable<Artist>> GetAllWithMusicAsync()
        {
            return await MusicMarketDbContext.Artists.Include(x => x.Musics)
                                                     .ToListAsync();
        }

        public async Task<Artist> GetWithMusicByIdAsync(int id)
        {
            return await MusicMarketDbContext.Artists
                .Include(x => x.Musics)
                 .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
