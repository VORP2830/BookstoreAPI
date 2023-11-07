using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Task<IEnumerable<Person>> GetAll();
        Task<Person> GetById(long id);
    }
}