using System.Collections.Generic;
using System.Threading.Tasks;
using Property.Core;
using Property.Core.IServices;
using Property.Core.Models;

namespace Property.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<City> CreateCity(City newCity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteCity(City city)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _unitOfWork.Cities
                .GetAllCities();
        }

        public async Task<City> GetCityById(int id)
        {
            return await _unitOfWork.Cities
            .SingleOrDefaultAsync(m => m.Id == id);
        }

        public Task UpdateCity(City cityToBeUpdated, City city)
        {
            throw new System.NotImplementedException();
        }
    }
}