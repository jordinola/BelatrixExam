using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Repository.MySql.Configurations
{
    public class InvoiceLineConfig : IEntityTypeConfiguration<InvoiceLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder
                .ToTable("invoice_line")
                .HasKey(x => x.InvoiceLineId)
                .HasName("pk_invoice_line_id");

            builder
                .HasIndex(x => x.InvoiceId)
                .HasName("idx_fk_invoice_id");

            builder
                .HasIndex(x => x.Track)
                .HasName("idx_fk_track_id");

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
                .HasConstraintName("fk_invoice_invoice_lines");

            builder
                .HasOne(x => x.Track)
                .WithMany(x => x.InvoiceLines)
                .HasForeignKey(x => x.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_track_invoice_lines");
        }
    }
}
