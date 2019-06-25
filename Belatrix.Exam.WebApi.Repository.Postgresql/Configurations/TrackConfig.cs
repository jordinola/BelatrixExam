using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Repository.PostgreSql.Configurations
{
    internal class TrackConfig : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder
                .ToTable("track")
                .HasKey(x => x.TrackId)
                .HasName("track_id_pkey");

            builder
                .HasIndex(x => x.AlbumId)
                .HasName("album_id_idx");

            builder
                .HasIndex(x => x.MediaTypeId)
                .HasName("media_type_id_idx");

            builder
                .HasIndex(x => x.GenreId)
                .HasName("genre_id_idx");

            builder
                .Property(x => x.TrackId)
                .HasColumnName("track_id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(x => x.AlbumId)
                .HasColumnName("album_id");

            builder
                .Property(x => x.MediaTypeId)
                .HasColumnName("media_type_id")
                .IsRequired();

            builder
                .Property(x => x.GenreId)
                .HasColumnName("genre_id");

            builder
                .Property(x => x.Composer)
                .HasColumnName("composer")
                .HasColumnType("varchar")
                .HasMaxLength(220);

            builder
                .Property(x => x.Milliseconds)
                .HasColumnName("milliseconds")
                .IsRequired();

            builder
                .Property(x => x.Bytes)
                .HasColumnName("bytes");

            builder
                .Property(x => x.UnitPrice)
                .HasColumnName("unit_price")
                .HasColumnType("numeric(10,2)")
                .IsRequired();

            builder
                .HasMany(x => x.PlaylistTracks)
                .WithOne(x => x.Track)
                .HasForeignKey(x => x.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("playlist_tracks__track__fk");

            builder
                .HasOne(x => x.MediaType)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.MediaTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("media_type__tracks__fk");

            builder
                .HasOne(x => x.Genre)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("genre_tracks_fk");

            builder
                .HasOne(x => x.Album)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.AlbumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("album_tracks_fk");

            builder
                .HasMany(x => x.InvoiceLines)
                .WithOne(x => x.Track)
                .HasForeignKey(x => x.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoice_lines__track__fk");
        }
    }
}
