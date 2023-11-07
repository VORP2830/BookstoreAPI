using Bookstore.Application.DTOs;

namespace Bookstore.Application.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDTO>> GetAll(); 
        Task<PersonDTO> GetById(long id); 
        Task<PersonDTO> Create(PersonDTO model); 
        Task<PersonDTO> Update(PersonDTO model); 
        Task<PersonDTO> Delete(long id); 
    }
}