using System.Collections.Generic;
using System.Data.Entity;
using TaskApp.Entities;

namespace TaskApp.Repository
{
    public class EFDbContext : DbContext
    {
        public DbSet<App> Apps { get; set; }
        public DbSet<Correction> Corrections { get; set; }
      
        public EFDbContext(string connectionString) : base(nameOrConnectionString: connectionString)
        { }
    }
}