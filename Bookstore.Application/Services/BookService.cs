
using AutoMapper;
using Bookstore.Application.DTOs;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Exceptions;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<BookDTO>> GetAll()
        {
            IEnumerable<Book> books = await _unitOfWork.BookRepository.GetAll();
            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }
        public async Task<BookDTO> GetById(long id)
        {
            Book book = await _unitOfWork.BookRepository.GetById(id);
            return _mapper.Map<BookDTO>(book);
        }
        public async Task<BookDTO> Create(BookDTO model)
        {
            Book book = _mapper.Map<Book>(model);
            _unitOfWork.BookRepository.Add(book);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<BookDTO>(book);
        }
        public async Task<BookDTO> Update(BookDTO model)
        {
            Book book = await _unitOfWork.BookRepository.GetById(model.Id);
            if(book == null) throw new BookstoreException("Livro não encontrado");
            _mapper.Map(book, model);
            _unitOfWork.BookRepository.Update(book);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<BookDTO>(book);
        }
        public async Task<BookDTO> Delete(long id)
        {
            Book book = await _unitOfWork.BookRepository.GetById(id);
            book.SetActive(false);
            _unitOfWork.BookRepository.Update(book);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<BookDTO>(book);
        }
    }
}