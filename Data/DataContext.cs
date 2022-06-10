using Microsoft.EntityFrameworkCore;
using Models;
using Data.Configurations;

namespace Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ToysModel> Toys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Super nice to have - Lets use another approach to apply all the configurations 
            modelBuilder.ApplyConfiguration(new ToysConfig());
        }
    }


}
