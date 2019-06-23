using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Repository.MySql.Configurations
{
    public class ArtistConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder
                .ToTable("artist")
                .HasKey(x => x.ArtistId)
                .HasName("pk_artist_id");

            builder
                .Property(x => x.ArtistId)
                .HasColumnName("artist_id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar")
                .HasMaxLength(120);

            builder
                .HasMany(x => x.Albums)
                .WithOne(x => x.Artist)
                .HasForeignKey(x => x.AlbumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_artist_album");
        }
    }
}
