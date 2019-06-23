using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Repository.MySql.Configurations
{
    public class PlaylistTrackConfig : IEntityTypeConfiguration<PlaylistTrack>
    {
        public void Configure(EntityTypeBuilder<PlaylistTrack> builder)
        {
            builder
                .ToTable("playlist_track")
                .HasKey(x => x.PlaylistId)
                .HasName("playlist_id");

            builder
                .ToTable("playlist_track")
                .HasKey(x => x.TrackId)
                .HasName("track_id");

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
                .HasForeignKey("fk_playlist_playlist_tracks");

            builder
                .HasOne(x => x.Track)
                .WithMany(x => x.PlaylistTracks)
                .HasForeignKey(x => x.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey("fk_track_playlist_tracks");
        }
    }
}
