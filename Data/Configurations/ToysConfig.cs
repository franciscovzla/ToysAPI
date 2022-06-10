using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Data.Configurations
{
    public class ToysConfig : IEntityTypeConfiguration<ToysModel>
    {
        public void Configure (EntityTypeBuilder<ToysModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Name).IsRequired().HasMaxLength(50);
            builder.HasData(GetToys());
        }

        private List<ToysModel> GetToys()
        {
            return new List<ToysModel>()
            {
                new ToysModel() { Id = 1, Name = "Toy 1", Description = "Description toy 1", Company = "Company toy 1", AgeRestriction = 10, Price = 10 },
                new ToysModel() { Id = 2, Name = "Toy 2", Description = "Description toy 2", Company = "Company toy 2", AgeRestriction = 10, Price = 20 },
                new ToysModel() { Id = 3, Name = "Toy 3", Description = "Description toy 3", Company = "Company toy 3", AgeRestriction = 10, Price = 30 },
                new ToysModel() { Id = 4, Name = "Toy 4", Description = "Description toy 4", Company = "Company toy 4", AgeRestriction = 10, Price = 40 },
                new ToysModel() { Id = 5, Name = "Toy 5", Description = "Description toy 5", Company = "Company toy 5", AgeRestriction = 10, Price = 50 },

            };
        }
    }
}
