using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Bookstore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infra.Data.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context) : base(context)
        { 
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.Where(p => p.Active == true).ToListAsync();
        }
        public async Task<Book> GetById(long id)
        {
            return await _context.Books.FirstOrDefaultAsync(p => p.Active == true && p.Id == id);
        }
    }
}