using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Belatrix.Exam.WebApi.Repository.MySql.Configurations
{
    public class AlbumConfig : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder
                .ToTable("album")
                .HasKey(x => x.AlbumId)
                .HasName("pk_album_id");

            builder
                .HasIndex(x => x.ArtistId)
                .HasName("idx_fk_artist_id");

            builder
                .Property(x => x.AlbumId)
                .HasColumnName("album_id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Title)
                .HasColumnName("title")
                .HasColumnType("nvarchar")
                .HasMaxLength(160)
                .IsRequired();

            builder
                .Property(x => x.ArtistId)
                .IsRequired();

            builder
                .HasOne(x => x.Artist)
                .WithMany(x => x.Albums)
                .HasForeignKey(x => x.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_artist_album");
        }
    }
}
