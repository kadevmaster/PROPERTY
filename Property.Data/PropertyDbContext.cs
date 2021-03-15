using Microsoft.EntityFrameworkCore;
using Property.Core.Models;
using Property.Data.Configurations;

namespace Property.Data
{
    public class PropertyDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public PropertyDbContext(DbContextOptions<PropertyDbContext> options)
        : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
            .ApplyConfiguration(new CityConfiguration());
        }
    }
}