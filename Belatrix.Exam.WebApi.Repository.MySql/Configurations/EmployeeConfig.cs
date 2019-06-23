using Belatrix.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.Exam.WebApi.Repository.MySql.Configurations
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .ToTable("employee")
                .HasKey(x => x.EmployeeId)
                .HasName("pk_employee_id");

            builder
                .HasIndex(x => x.ReportsTo)
                .HasName("idx_fk_reports_to");

            builder
                .Property(x => x.EmployeeId)
                .HasColumnName("employee_id")
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("nvarchar")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.LastName)
                .HasColumnName("last_name")
                .HasColumnType("nvarchar")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.Title)
                .HasColumnName("title")
                .HasColumnType("nvarchar")
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
                .HasMaxLength(60);

            builder
                .HasOne(x => x.Leader)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.ReportsTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_leader_employees");

            builder
                .HasMany(x => x.Employees)
                .WithOne(x => x.Leader)
                .HasForeignKey(x => x.ReportsTo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_employees_leader");

            builder
                .HasMany(x => x.Customers)
                .WithOne(x => x.SupportEmployee)
                .HasForeignKey(x => x.SupportRepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_customers_support_employee");
        }
    }
}
