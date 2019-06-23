using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Repository.MySql.Configurations
{
    public class PlaylistConfig : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder
                .ToTable("playlist")
                .HasKey(x => x.PlaylistId)
                .HasName("pk_playlist_id");

            builder
                .Property(x => x.PlaylistId)
                .HasColumnName("playlist_id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar")
                .HasMaxLength(120);

            builder
                .HasMany(x => x.PlaylistTracks)
                .WithOne(x => x.Playlist)
                .HasForeignKey(x => x.PlaylistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_playlist_tracks_playlist");
        }
    }
}
