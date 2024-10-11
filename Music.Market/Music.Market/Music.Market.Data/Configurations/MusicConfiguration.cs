using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Market.Data.Configurations
{
    public class MusicConfiguration : IEntityTypeConfiguration<Core.Models.Music>
    {
        public void Configure(EntityTypeBuilder<Core.Models.Music> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder
                .HasOne(x => x.Artist)
                .WithMany(x => x.Musics)
                .HasForeignKey(x => x.ArtistId);
            builder.ToTable("Musics");
           
        }
    }
}
