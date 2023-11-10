using Microsoft.AspNetCore.Mvc;
using Bookstore.Application.DTOs;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace Bookstore.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CopyBookController : ControllerBase
    {
        private readonly ICopyBookService _copyBookService;

        public CopyBookController(ICopyBookService copyBookService)
        {
            _copyBookService = copyBookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _copyBookService.GetAll();
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
                    Message = "Erro ao tentar obter a lista de cópias de livros"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _copyBookService.GetById(id);
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
                    Message = "Erro ao tentar obter a cópia do livro"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CopyBookDTO model)
        {
            try
            {
                var result = await _copyBookService.Create(model);
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
                    Message = "Erro ao tentar criar a cópia do livro"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CopyBookDTO model)
        {
            try
            {
                var result = await _copyBookService.Update(model);
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
                    Message = "Erro ao tentar atualizar a cópia do livro"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _copyBookService.Delete(id);
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
                    Message = "Erro ao tentar excluir a cópia do livro"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
