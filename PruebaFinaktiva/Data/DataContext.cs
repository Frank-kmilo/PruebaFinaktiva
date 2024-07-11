using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PruebaFinaktiva.Data.Entities;

namespace PruebaFinaktiva.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {                
        }


        public DbSet<EventLog> EventLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _ = modelBuilder.Entity<EventLog>().HasIndex(x => x.Id).IsUnique();
        }
    }
}
