using Microsoft.EntityFrameworkCore;

namespace Music.Market.Data.Configurations
{
    internal class MusicConfiguration : IEntityTypeConfiguration<Core.Models.Music>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Core.Models.Music> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.Artist).WithMany(x => x.Musics).HasForeignKey(x => x.ArtistId);
            builder.ToTable("Musics");
        }
    }
}
