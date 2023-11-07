using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Bookstore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infra.Data.Repositories
{
    public class CopyBookRepository : GenericRepository<CopyBook>, ICopyBookRepository
    {
        private readonly ApplicationDbContext _context;
        public CopyBookRepository(ApplicationDbContext context) : base(context)
        { 
            _context = context;
        }
        public async Task<IEnumerable<CopyBook>> GetAll()
        {
            return await _context.CopyBooks.Where(p => p.Active == true).ToListAsync();
        }
        public async Task<CopyBook> GetById(long id)
        {
            return await _context.CopyBooks.FirstOrDefaultAsync(p => p.Active == true && p.Id == id);
        }
    }
}