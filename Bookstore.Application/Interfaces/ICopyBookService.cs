using Bookstore.Application.DTOs;

namespace Bookstore.Application.Interfaces
{
    public interface ICopyBookService
    {
        Task<IEnumerable<CopyBookDTO>> GetAll(); 
        Task<CopyBookDTO> GetById(long id); 
        Task<CopyBookDTO> Create(CopyBookDTO model); 
        Task<CopyBookDTO> Update(CopyBookDTO model); 
        Task<CopyBookDTO> Delete(long id); 
    }
}