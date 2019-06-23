using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Repository.MySql.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .ToTable("customer")
                .HasKey(x => x.CustomerId)
                .HasName("pk_customer_id");

            builder
                .HasIndex(x => x.SupportRepId)
                .HasName("idx_fk_support_rep_id");

            builder
                .Property(x => x.CustomerId)
                .HasColumnName("customer_id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("nvarchar")
                .HasMaxLength(40)
                .IsRequired();

            builder
                .Property(x => x.LastName)
                .HasColumnName("last_name")
                .HasColumnType("nvarchar")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.Company)
                .HasColumnName("company")
                .HasColumnType("nvarchar")
                .HasMaxLength(80);

            builder
                .Property(x => x.Address)
                .HasColumnName("address")
                .HasColumnType("nvarchar")
                .HasMaxLength(70);

            builder
                .Property(x => x.City)
                .HasColumnName("city")
                .HasColumnType("nvarchar")
                .HasMaxLength(40);

            builder
                .Property(x => x.State)
                .HasColumnName("state")
                .HasColumnType("nvarchar")
                .HasMaxLength(40);

            builder
                .Property(x => x.Country)
                .HasColumnName("country")
                .HasColumnType("nvarchar")
                .HasMaxLength(40);

            builder
                .Property(x => x.PostalCode)
                .HasColumnName("postal_code")
                .HasColumnType("nvarchar")
                .HasMaxLength(10);

            builder
                .Property(x => x.Phone)
                .HasColumnName("phone")
                .HasColumnType("nvarchar")
                .HasMaxLength(24);

            builder
                .Property(x => x.Fax)
                .HasColumnName("fax")
                .HasColumnType("nvarchar")
                .HasMaxLength(24);

            builder
                .Property(x => x.Email)
                .HasColumnName("email")
                .HasColumnType("nvarchar")
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
                .HasConstraintName("fk_invoice_customer");

            builder
                .HasOne(x => x.SupportEmployee)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.SupportRepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_support_employee_customer");
        }
    }
}
