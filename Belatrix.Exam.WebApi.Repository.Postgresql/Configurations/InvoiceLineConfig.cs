using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Repository.PostgreSql.Configurations
{
    internal class InvoiceLineConfig : IEntityTypeConfiguration<InvoiceLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder
                .ToTable("invoice_line")
                .HasKey(x => x.InvoiceLineId)
                .HasName("invoice_line_id_pkey");

            builder
                .HasIndex(x => x.InvoiceId)
                .HasName("invoice_id_idx");

            builder
                .HasIndex(x => x.TrackId)
                .HasName("track_id_idx");

            builder
                .Property(x => x.InvoiceLineId)
                .HasColumnName("invoice_line_id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.InvoiceId)
                .HasColumnName("invoice_id")
                .IsRequired();

            builder
                .Property(x => x.TrackId)
                .HasColumnName("track_id")
                .IsRequired();

            builder
                .Property(x => x.UnitPrice)
                .HasColumnName("unit_price")
                .HasColumnType("numeric(10,2)")
                .IsRequired();

            builder
                .Property(x => x.Quantity)
                .HasColumnName("quantity")
                .IsRequired();

            builder
                .HasOne(x => x.Invoice)
                .WithMany(x => x.InvoiceLines)
                .HasForeignKey(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoice__invoice_lines__fk");

            builder
                .HasOne(x => x.Track)
                .WithMany(x => x.InvoiceLines)
                .HasForeignKey(x => x.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("track__invoice_lines__fk");
        }
    }
}
