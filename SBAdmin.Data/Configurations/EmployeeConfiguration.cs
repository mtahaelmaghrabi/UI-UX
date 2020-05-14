using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBAdmin.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBAdmin.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasKey(a => a.EmployeeID);

            builder
                .Property(m => m.EmployeeName)
                .IsRequired()
                .HasMaxLength(300);

            builder
                .ToTable("Employee");
        }
    }
}