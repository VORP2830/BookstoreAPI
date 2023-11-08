using Bookstore.Application.DTOs;

namespace Bookstore.Application.Interfaces
{
    public interface IRentService
    {
        Task<IEnumerable<RentDTO>> GetAll();
        Task<RentDTO> GetById(long id); 
        Task<RentDTO> Create(RentDTO model); 
        Task<RentDTO> Update(RentDTO model); 
        Task<RentDTO> Delete(long id); 
    }
}