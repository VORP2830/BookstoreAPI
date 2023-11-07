using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Bookstore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infra.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        { 
            _context = context;
        }
        public async Task<User> GetById(long id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Active == true && u.Id == id);
        }
        public async Task<User> GetByUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Active == true && u.UserName == userName);
        }
    }
}