using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Repository.MySql.Configurations
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .ToTable("customer")
                .HasKey(x => x.CustomerId)
                .HasName("customer_id_pkey");

            builder
                .HasIndex(x => x.SupportRepId)
                .HasName("support_rep_id_idx");

            builder
                .Property(x => x.CustomerId)
                .HasColumnName("customer_id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();

            builder
                .Property(x => x.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.Company)
                .HasColumnName("company")
                .HasColumnType("varchar")
                .HasMaxLength(80);

            builder
                .Property(x => x.Address)
                .HasColumnName("address")
                .HasColumnType("varchar")
                .HasMaxLength(70);

            builder
                .Property(x => x.City)
                .HasColumnName("city")
                .HasColumnType("varchar")
                .HasMaxLength(40);

            builder
                .Property(x => x.State)
                .HasColumnName("state")
                .HasColumnType("varchar")
                .HasMaxLength(40);

            builder
                .Property(x => x.Country)
                .HasColumnName("country")
                .HasColumnType("varchar")
                .HasMaxLength(40);

            builder
                .Property(x => x.PostalCode)
                .HasColumnName("postal_code")
                .HasColumnType("varchar")
                .HasMaxLength(10);

            builder
                .Property(x => x.Phone)
                .HasColumnName("phone")
                .HasColumnType("varchar")
                .HasMaxLength(24);

            builder
                .Property(x => x.Fax)
                .HasColumnName("fax")
                .HasColumnType("varchar")
                .HasMaxLength(24);

            builder
                .Property(x => x.Email)
                .HasColumnName("email")
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .IsRequired();

            builder
                .Property(x => x.SupportRepId)
                .HasColumnName("support_rep_id");

            builder
                .HasMany(x => x.Invoices)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoice_customer_fk");

            builder
                .HasOne(x => x.SupportEmployee)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.SupportRepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("support_employee__customer__fk");
        }
    }
}
