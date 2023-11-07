using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces
{
    public interface ICopyBookRepository : IGenericRepository<CopyBook>
    {
        Task<IEnumerable<CopyBook>> GetAll();
        Task<CopyBook> GetById(long id);
    }
}