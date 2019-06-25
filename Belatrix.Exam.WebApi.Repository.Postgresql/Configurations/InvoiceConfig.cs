using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Repository.PostgreSql.Configurations
{
    internal class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder
                .ToTable("invoice")
                .HasKey(x => x.InvoiceId)
                .HasName("invoice_id_pkey");

            builder
                .HasIndex(x => x.CustomerId)
                .HasName("customer_id_idx");

            builder
                .Property(x => x.InvoiceId)
                .HasColumnName("invoice_id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            builder
                .Property(x => x.InvoiceDate)
                .HasColumnName("invoice_date")
                .IsRequired();

            builder
                .Property(x => x.BillingAddress)
                .HasColumnName("billing_address")
                .HasColumnType("varchar")
                .HasMaxLength(70);

            builder
                .Property(x => x.BillingCity)
                .HasColumnName("billing_city")
                .HasColumnType("varchar")
                .HasMaxLength(40);

            builder
                .Property(x => x.BillingState)
                .HasColumnName("billing_state")
                .HasColumnType("varchar")
                .HasMaxLength(40);

            builder
                .Property(x => x.BillingCountry)
                .HasColumnName("billing_country")
                .HasColumnType("varchar")
                .HasMaxLength(40);

            builder
                .Property(x => x.BillingPostalCode)
                .HasColumnName("billing_postal_code")
                .HasColumnType("varchar")
                .HasMaxLength(10);

            builder
                .Property(x => x.Total)
                .HasColumnName("total")
                .HasColumnType("numeric(10,2)")
                .IsRequired();

            builder
                .HasOne(x => x.Customer)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_invoices_fk");

            builder
                .HasMany(x => x.InvoiceLines)
                .WithOne(x => x.Invoice)
                .HasForeignKey(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoice_lines__invoice__fk");
        }
    }
}
