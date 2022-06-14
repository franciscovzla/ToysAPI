
using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
           


            builder.HasData(GetCompanies());

        }

        private List<Company> GetCompanies()
        {
            return new List<Company>()
            {
                new Company() { Id = 1, Name = "Company 1"},
                new Company() { Id = 2, Name = "Company 2"},
                new Company() { Id = 3, Name = "Company 3"},
                new Company() { Id = 4, Name = "Company 4"},
                new Company() { Id = 5, Name = "Company 5"},

            };
        }
    }
}
