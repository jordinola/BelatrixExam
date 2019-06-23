using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Repository.MySql.Configurations
{
    public class TrackConfig : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder
                .ToTable("track")
                .HasKey(x => x.TrackId)
                .HasName("pk_track_id");

            builder
                .HasIndex(x => x.AlbumId)
                .HasName("idx_fk_album_id");

            builder
                .HasIndex(x => x.MediaTypeId)
                .HasName("idx_fk_media_type_id");

            builder
                .HasIndex(x => x.GenreId)
                .HasName("idx_fk_genre_id");

            builder
                .Property(x => x.TrackId)
                .HasColumnName("track_id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar")
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
                .HasColumnType("nvarchar")
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
                .HasConstraintName("fk_playlist_tracks_track");

            builder
                .HasOne(x => x.MediaType)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.MediaTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_media_type_tracks");

            builder
                .HasOne(x => x.Genre)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_genre_tracks");

            builder
                .HasOne(x => x.Album)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.AlbumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_album_tracks");

            builder
                .HasMany(x => x.InvoiceLines)
                .WithOne(x => x.Track)
                .HasForeignKey(x => x.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_invoice_lines_track");
        }
    }
}
