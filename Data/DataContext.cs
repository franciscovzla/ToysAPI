using Microsoft.EntityFrameworkCore;
using Models;
using Data.Configurations;
using Data.Extensions;

namespace Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Toys> Toys { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyCustomConfigurations();
        }
    }


}
