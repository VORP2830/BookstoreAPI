

using AutoMapper;
using Bookstore.Application.DTOs;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Exceptions;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PersonService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<PersonDTO>> GetAll()
        {
            IEnumerable<Person> people = await _unitOfWork.PersonRepository.GetAll();
            return _mapper.Map<IEnumerable<PersonDTO>>(people);
        }

        public async Task<PersonDTO> GetById(long id)
        {
            Person person = await _unitOfWork.PersonRepository.GetById(id);
            return _mapper.Map<PersonDTO>(person);
        }
        public async Task<PersonDTO> Create(PersonDTO model)
        {
            Person person = _mapper.Map<Person>(model);
            _unitOfWork.PersonRepository.Add(person);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PersonDTO>(person);
        }
        public async Task<PersonDTO> Update(PersonDTO model)
        {
            Person person = await _unitOfWork.PersonRepository.GetById(model.Id);
            if(person == null) throw new BookstoreException("Pessoa não encontrada");
            _mapper.Map(person, model);
            _unitOfWork.PersonRepository.Update(person);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PersonDTO>(person);
        }
        public async Task<PersonDTO> Delete(long id)
        {
            Person person = await _unitOfWork.PersonRepository.GetById(id);
            person.SetActive(false);
            _unitOfWork.PersonRepository.Update(person);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PersonDTO>(person);
        }
    }
}