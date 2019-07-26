using Microsoft.EntityFrameworkCore;
using System;

namespace AutomaticEntity
{
    internal class InternalContext : DbContext
    {
        private string connectionString;
        private ModelBuilder modelBuilder;
        public InternalContext(string connStr)
        {
            connectionString = connStr;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder mBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder = mBuilder;
        }
        public void EnsureEntityExists(Type type)
        {
            modelBuilder.Model.GetOrAddEntityType(type);
        }
    }
}
