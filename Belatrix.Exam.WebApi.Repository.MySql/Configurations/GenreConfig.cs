using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Repository.MySql.Configurations
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder
                .ToTable("genre")
                .HasKey(x => x.GenreId)
                .HasName("pk_genre_id");

            builder
                .Property(x => x.GenreId)
                .HasColumnName("genre_id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar")
                .HasMaxLength(120);

            builder
                .HasMany(x => x.Tracks)
                .WithOne(x => x.Genre)
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tracks_genre");
        }
    }
}
