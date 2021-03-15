using System.Collections.Generic;
using System.Threading.Tasks;
using Property.Core.Models;

namespace Property.Core.IServices
{
    public interface ICityService
    {
         Task<IEnumerable<City>> GetAllCities();
        Task<City> GetCityById(int id);
        Task<City> CreateCity(City newCity);
        Task UpdateCity(City cityToBeUpdated, City city);
        Task DeleteCity(City city);
    }
}