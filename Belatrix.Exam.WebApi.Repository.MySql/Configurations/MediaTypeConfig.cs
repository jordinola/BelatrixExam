using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Repository.MySql.Configurations
{
    public class MediaTypeConfig : IEntityTypeConfiguration<MediaType>
    {
        public void Configure(EntityTypeBuilder<MediaType> builder)
        {
            builder
                .ToTable("media_type")
                .HasKey(x => x.MediaTypeId)
                .HasName("pk_media_type_id");

            builder
                .Property(x => x.MediaTypeId)
                .HasColumnName("media_type_id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar")
                .HasMaxLength(120);

            builder
                .HasMany(x => x.Tracks)
                .WithOne(x => x.MediaType)
                .HasForeignKey(x => x.MediaTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tracks_media_type");
        }
    }
}
