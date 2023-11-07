using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces
{
    public interface IRentRepository : IGenericRepository<Rent>
    {
        Task<IEnumerable<Rent>> GetAll();
        Task<Rent> GetById(long id);
        Task<IEnumerable<Rent>> GetByCopyBookId(long copyBookId);
        Task<IEnumerable<Rent>> GetByPersonId(long personId);
        Task<IEnumerable<Rent>> GetByCopyBookIdAndOperation(long copyBookId, string charOperation);
    }
}