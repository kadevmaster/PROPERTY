using System.Threading.Tasks;
using Property.Core;
using Property.Core.IRepositories;
using Property.Data.Repositories;

namespace Property.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PropertyDbContext _context;
        private CityRepository _cityRepository;

        public UnitOfWork(PropertyDbContext context)
        {
            this._context = context;
        }
        public ICityRepository Cities => _cityRepository = _cityRepository ?? new CityRepository(_context);
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}