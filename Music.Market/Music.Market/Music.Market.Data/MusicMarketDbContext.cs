using Microsoft.EntityFrameworkCore;
using Music.Market.Core.Models;
using Music.Market.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Market.Data
{
    public class MusicMarketDbContext:DbContext 
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Core.Models.Music> Musics { get; set; }

        public MusicMarketDbContext(DbContextOptions<MusicMarketDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new MusicConfiguration());



        }

    }
}
