using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Repository.PostgreSql.Configurations
{
    internal class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .ToTable("employee")
                .HasKey(x => x.EmployeeId)
                .HasName("employee_id_pkey");

            builder
                .HasIndex(x => x.ReportsTo)
                .HasName("reports_to_idx");

            builder
                .Property(x => x.EmployeeId)
                .HasColumnName("employee_id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.Title)
                .HasColumnName("title")
                .HasColumnType("varchar")
                .HasMaxLength(30);

            builder
                .Property(x => x.ReportsTo)
                .HasColumnName("reports_to");

            builder
                .Property(x => x.BirthDate)
                .HasColumnName("birth_date");

            builder
                .Property(x => x.HireDate)
                .HasColumnName("hire_date");

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
                .HasMaxLength(60);

            builder
                .HasOne(x => x.Leader)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.ReportsTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("leader_employees_fk");

            builder
                .HasMany(x => x.Employees)
                .WithOne(x => x.Leader)
                .HasForeignKey(x => x.ReportsTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_leader_fk");

            builder
                .HasMany(x => x.Customers)
                .WithOne(x => x.SupportEmployee)
                .HasForeignKey(x => x.SupportRepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customers__support_employee__fk");
        }
    }
}
