using AutoMapper;
using Bookstore.Application.DTOs;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Exceptions;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Application.Services
{
    public class CopyBookService : ICopyBookService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CopyBookService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CopyBookDTO>> GetAll()
        {
            IEnumerable<CopyBook> copyBooks = await _unitOfWork.CopyBookRepository.GetAll();
            return _mapper.Map<IEnumerable<CopyBookDTO>>(copyBooks);
        }
        public async Task<CopyBookDTO> GetById(long id)
        {
           CopyBook copyBook = await _unitOfWork.CopyBookRepository.GetById(id);
           return _mapper.Map<CopyBookDTO>(copyBook);
        }
        public async Task<CopyBookDTO> Create(CopyBookDTO model)
        {
            CopyBook copyBook = _mapper.Map<CopyBook>(model);
            _unitOfWork.CopyBookRepository.Add(copyBook);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CopyBookDTO>(copyBook);
        }
        public async Task<CopyBookDTO> Update(CopyBookDTO model)
        {
            CopyBook copyBook = await _unitOfWork.CopyBookRepository.GetById(model.Id);
            if(copyBook == null) throw new BookstoreException("Copia não encontrada");
            _mapper.Map(copyBook, model);
            _unitOfWork.CopyBookRepository.Update(copyBook);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CopyBookDTO>(copyBook);
        }
        public async Task<CopyBookDTO> Delete(long id)
        {
            CopyBook copyBook = await _unitOfWork.CopyBookRepository.GetById(id);
            copyBook.SetActive(false);
            _unitOfWork.CopyBookRepository.Update(copyBook);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CopyBookDTO>(copyBook);
        }
    }
}