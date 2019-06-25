using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Repository.PostgreSql.Configurations
{
    internal class PlaylistConfig : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder
                .ToTable("playlist")
                .HasKey(x => x.PlaylistId)
                .HasName("playlist_id_pkey");

            builder
                .Property(x => x.PlaylistId)
                .HasColumnName("playlist_id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("varchar")
                .HasMaxLength(120);

            builder
                .HasMany(x => x.PlaylistTracks)
                .WithOne(x => x.Playlist)
                .HasForeignKey(x => x.PlaylistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("playlist_tracks__playlist__fk");
        }
    }
}
