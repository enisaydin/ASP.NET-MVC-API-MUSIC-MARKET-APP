using Music.Market.Core;
using Music.Market.Core.Repositories;
using Music.Market.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Market.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicMarketDbContext context;
        private MusicRepository musicRepository;
        private ArtistRepository artistRepository;
        public UnitOfWork(MusicMarketDbContext _context)
        {
            context = _context;
        }
        public IMusicRepository Musics => musicRepository = musicRepository ?? new MusicRepository(context);

        public IArtistRepository Artists => artistRepository = artistRepository ?? new ArtistRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }
        public void Dispose() 
        {
            context.Dispose();
        }
    }
}
