using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Bookstore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infra.Data.Repositories
{
    public class RentRepository : GenericRepository<Rent>, IRentRepository
    {
        private readonly ApplicationDbContext _context;
        public RentRepository(ApplicationDbContext context) : base(context)
        { 
            _context = context;
        }
        public async Task<IEnumerable<Rent>> GetAll()
        {
            return await _context.Rents.Where(p => p.Active == true).ToListAsync();
        }
        public async Task<Rent> GetById(long id)
        {
            return await _context.Rents.FirstOrDefaultAsync(p => p.Active == true && p.Id == id);
        }
        public async Task<IEnumerable<Rent>> GetByCopyBookId(long copyBookId)
        {
            return await _context.Rents.Where(r => r.Active == true && r.CopyBookId == copyBookId).ToListAsync();
        }
        public async Task<IEnumerable<Rent>> GetByCopyBookIdAndOperation(long copyBookId, string charOperation)
        {
            return await _context.Rents.Where(r => r.Active == true && r.CopyBookId == copyBookId && r.CharOperation == charOperation).OrderBy(r => r.Id).ToListAsync();
        }
        public async Task<IEnumerable<Rent>> GetByPersonId(long personId)
        {
            return await _context.Rents.Where(r => r.Active == true && r.PersonId == personId).ToListAsync();
        }
    }
}