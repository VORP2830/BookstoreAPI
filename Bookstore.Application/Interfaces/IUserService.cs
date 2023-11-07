using Bookstore.Application.DTOs;

namespace Bookstore.Application.Interfaces
{
    public interface IUserService
    {
        Task<Object> Register(UserDTO model);
        Task<Object> Login(UserLoginDTO model);
        Task<UserDTO> Update(UserDTO model, long userId);
        Task<UserDTO> Get(long userId);
    }
}