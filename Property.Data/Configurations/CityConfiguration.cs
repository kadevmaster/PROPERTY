using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Property.Core.Models;

namespace Property.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
            .Property(m => m.ParentId).IsRequired(false);

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}