using Bookstore.Domain.Interfaces;
using Bookstore.Infra.Data.Context;

namespace Bookstore.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository => new UserRepository(_context);
        public IPersonRepository PersonRepository => new PersonRepository(_context);
        public IBookRepository BookRepository => new BookRepository(_context);
        public ICopyBookRepository CopyBookRepository => new CopyBookRepository(_context);
        public IRentRepository RentRepository => new RentRepository(_context);
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}