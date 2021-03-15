using Property.Core.IRepositories;

namespace Property.Core
{
    public interface IUnitOfWork
    {
        ICityRepository Cities { get; }
    }
}