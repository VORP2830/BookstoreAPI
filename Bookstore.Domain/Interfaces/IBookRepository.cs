using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(long id);
    }
}