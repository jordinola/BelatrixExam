using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.Exam.WebApi.Repository.PostgreSql.Configurations
{
    internal class AlbumConfig : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder
                .ToTable("album")
                .HasKey(x => x.AlbumId)
                .HasName("album_id_pkey");

            builder
                .HasIndex(x => x.ArtistId)
                .HasName("artist_id_idx");

            builder
                .Property(x => x.AlbumId)
                .HasColumnName("album_id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Title)
                .HasColumnName("title")
                .HasColumnType("varchar")
                .HasMaxLength(160)
                .IsRequired();

            builder
                .Property(x => x.ArtistId)
                .HasColumnName("artist_id")
                .IsRequired();

            builder
                .HasOne(x => x.Artist)
                .WithMany(x => x.Albums)
                .HasForeignKey(x => x.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("artist_album_fk");
        }
    }
}
