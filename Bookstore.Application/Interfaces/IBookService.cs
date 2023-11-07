using Bookstore.Application.DTOs;

namespace Bookstore.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAll(); 
        Task<BookDTO> GetById(long id); 
        Task<BookDTO> Create(BookDTO model); 
        Task<BookDTO> Update(BookDTO model); 
        Task<BookDTO> Delete(long id); 
    }
}