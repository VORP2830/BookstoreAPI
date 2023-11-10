using Bookstore.Application.DTOs;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _bookService.GetAll();
                return Ok(result);
            }
            catch (BookstoreException ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar obter a lista de livros"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _bookService.GetById(id);
                return Ok(result);
            }
            catch (BookstoreException ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar obter o livro"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookDTO model)
        {
            try
            {
                var result = await _bookService.Create(model);
                return Ok(result);
            }
            catch (BookstoreException ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar criar o livro"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(BookDTO model)
        {
            try
            {
                var result = await _bookService.Update(model);
                return Ok(result);
            }
            catch (BookstoreException ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar atualizar o livro"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _bookService.Delete(id);
                return Ok(result);
            }
            catch (BookstoreException ex)
            {
                var errorResponse = new
                {
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
            catch (Exception)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar excluir o livro"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
