using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Repository.PostgreSql.Configurations
{
    internal class PlaylistTrackConfig : IEntityTypeConfiguration<PlaylistTrack>
    {
        public void Configure(EntityTypeBuilder<PlaylistTrack> builder)
        {
            builder
                .ToTable("playlist_track")
                .HasKey(x => new { x.PlaylistId, x.TrackId })
                .HasName("playlist_id__track_id__pkey");

            builder
                .Property(x => x.PlaylistId)
                .HasColumnName("playlist_id");

            builder
                .Property(x => x.TrackId)
                .HasColumnName("track_id");

            builder
                .HasOne(x => x.Playlist)
                .WithMany(x => x.PlaylistTracks)
                .HasForeignKey(x => x.PlaylistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("playlist__playlist_tracks__fk");

            builder
                .HasOne(x => x.Track)
                .WithMany(x => x.PlaylistTracks)
                .HasForeignKey(x => x.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("track__playlist_tracks__fk");
        }
    }
}
