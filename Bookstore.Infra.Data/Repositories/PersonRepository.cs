using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Bookstore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infra.Data.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _context.People.Where(p => p.Active == true).ToListAsync();
        }
        public async Task<Person> GetById(long id)
        {
            return await _context.People.FirstOrDefaultAsync(p => p.Active == true && p.Id == id);
        }
    }
}