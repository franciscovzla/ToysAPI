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
    public class ToysConfig : IEntityTypeConfiguration<Toys>
    {
        public void Configure (EntityTypeBuilder<Toys> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.AgeRestriction).IsRequired();
            builder.Property (x => x.Price).IsRequired().HasColumnType("decimal(18, 6)");
            builder.HasOne(x => x.Company)
                .WithMany(c => c.Toys)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired();
              
                
            builder.HasData(GetToys());
           
        }

        private List<Toys> GetToys()
        {
            return new List<Toys>()
            {
                new Toys() { Id = 1, Name = "Toy 1", Description = "Description toy 1", CompanyId = 1, AgeRestriction = 10, Price = 10 },
                new Toys() { Id = 2, Name = "Toy 2", Description = "Description toy 2", CompanyId = 2, AgeRestriction = 10, Price = 20 },
                new Toys() { Id = 3, Name = "Toy 3", Description = "Description toy 3", CompanyId = 3, AgeRestriction = 10, Price = 30 },
                new Toys() { Id = 4, Name = "Toy 4", Description = "Description toy 4", CompanyId = 4, AgeRestriction = 10, Price = 40 },
                new Toys() { Id = 5, Name = "Toy 5", Description = "Description toy 5", CompanyId = 5, AgeRestriction = 10, Price = 50 },

            };
        }

        }
    }

