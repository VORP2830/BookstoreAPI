using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUserName(string userName);
        Task<User> GetById(long id);
    }
}