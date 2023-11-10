using AutoMapper;
using Bookstore.Application.DTOs;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Exceptions;
using Bookstore.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Bookstore.Application.Services
{
    public class RentService : IRentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public RentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<RentDTO>> GetAll()
        {
            IEnumerable<Rent> rents = await _unitOfWork.RentRepository.GetAll();
            return _mapper.Map<IEnumerable<RentDTO>>(rents);
        }
        public async Task<RentDTO> GetById(long id)
        {
            Rent rent = await _unitOfWork.RentRepository.GetById(id);
            return _mapper.Map<RentDTO>(rent);
        }
        public async Task<RentDTO> Create(RentDTO model)
        {
            Rent rent = _mapper.Map<Rent>(model);
            if(model.CharOperation == "S")
            {
                if(!await IsCopyBookAvailable(model.CopyBookId))
                {
                    throw new BookstoreException("Copia indisponivel para aluguel");
                }
            }
            if(model.CharOperation == "E")
            {
                if(await IsCopyBookAvailable(model.CopyBookId))
                {
                    throw new BookstoreException("Não é possivel devolver um livro que voce nao pegou");
                }

            }
            if(!await CanPersonRentWithLateReturns(model.PersonId))
            {
                throw new BookstoreException("Pessoa não autorizada a realizar o aluguel. Atrasos constantes");
            }
            _unitOfWork.RentRepository.Add(rent);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<RentDTO>(rent);
        }
        public async Task<RentDTO> Update(RentDTO model)
        {
            Rent rent = await _unitOfWork.RentRepository.GetById(model.Id);
            if(rent == null) throw new BookstoreException("Aluguel não encontrado");
            if(model.CharOperation == "S")
            {
                if(!await IsCopyBookAvailable(model.CopyBookId))
                {
                    throw new BookstoreException("Copia indisponivel para aluguel");
                }
            }
            if(model.CharOperation == "E")
            {
                if(await IsCopyBookAvailable(model.CopyBookId))
                {
                    throw new BookstoreException("Não é possivel devolver um livro que voce não pegou");
                }

            }
            if(!await CanPersonRentWithLateReturns(model.PersonId))
            {
                throw new BookstoreException("Pessoa não autorizada a realizar o aluguel. Atrasos constantes");
            }
            _mapper.Map(rent, model);
            _unitOfWork.RentRepository.Add(rent);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<RentDTO>(rent);
        }
        public async Task<RentDTO> Delete(long id)
        {
            Rent rent = await _unitOfWork.RentRepository.GetById(id);
            if(rent == null) throw new BookstoreException("Aluguel não encontrado");
            rent.SetActive(false);
            _unitOfWork.RentRepository.Update(rent);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<RentDTO>(rent);
        }
        private async Task<bool> CanPersonRentWithLateReturns(long personId)
        {
            int lateRentalCount = 0;
            IEnumerable<Rent> rents = await _unitOfWork.RentRepository.GetByPersonId(personId);
            foreach(Rent rent in rents)
            {
                if(rent.IsLate == true)
                {
                    lateRentalCount++;
                }
            }
            return lateRentalCount < 2;
        }
        private async Task<bool> IsCopyBookAvailable(long copyBookId)
        {
            CopyBook copyBook = await _unitOfWork.CopyBookRepository.GetById(copyBookId);
            if (copyBook == null) throw new BookstoreException("Cópia não encontrada");
            IEnumerable<Rent> rents = await _unitOfWork.RentRepository.GetByCopyBookId(copyBookId);
            if (rents.IsNullOrEmpty())
            {
                return true;
            }
            Rent lastRent = rents.LastOrDefault();
            if (lastRent != null)
            {
                return lastRent.CharOperation == "E";
            }
            return true;
        }
    }
}