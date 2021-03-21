using Property.Core.IRepositories;
using System.Threading.Tasks;

namespace Property.Core
{
    public interface IUnitOfWork
    {
        ICityRepository Cities { get; }
        Task<int> CommitAsync();
    }
}