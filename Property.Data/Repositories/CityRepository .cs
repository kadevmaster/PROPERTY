using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Property.Core.IRepositories;
using Property.Core.Models;

namespace Property.Data.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(PropertyDbContext context)
        : base(context)
        { }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await PropertyDbContext.Cities
                        .ToListAsync();
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            return await PropertyDbContext.Cities
            .SingleOrDefaultAsync(m => m.Id == id);
        }

        private PropertyDbContext PropertyDbContext
        {
            get { return Context as PropertyDbContext; }
        }
    }
}