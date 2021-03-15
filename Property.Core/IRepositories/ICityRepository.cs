using System.Collections.Generic;
using System.Threading.Tasks;
using Property.Core.Models;

namespace Property.Core.IRepositories
{
    public interface ICityRepository: IRepository<City>
    {
        Task<IEnumerable<City>> GetAllCities();
        Task<City> GetCityByIdAsync(int id);
    }
}