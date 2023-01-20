using Core.EntityModels;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CRMContext : DbContext
    {
        public CRMContext(DbContextOptions options) : base(options)
        {
        }

        public CRMContext() : base(GetOptions())
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
        }

        private static DbContextOptions GetOptions()
        {
            string cs = @"Server=DESKTOP-ROPLCFM;Database=Day05;User Id=sa;Password=1;";
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), cs).Options;
        }
    }
}
