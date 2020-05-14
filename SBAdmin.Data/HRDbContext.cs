using Microsoft.EntityFrameworkCore;
using SBAdmin.Core.Models;
using SBAdmin.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBAdmin.Data
{
    public class HRDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddress { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployeeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=PC1\\SQL19; Initial Catalog=HR_AdminDB; Integrated Security=true;");
        }
    }
}
