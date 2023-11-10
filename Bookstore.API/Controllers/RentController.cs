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
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentService;

        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _rentService.GetAll();
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
                    Message = "Erro ao tentar obter a lista de aluguéis"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _rentService.GetById(id);
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
                    Message = "Erro ao tentar obter o aluguel"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(RentDTO model)
        {
            try
            {
                var result = await _rentService.Create(model);
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
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = "Erro ao tentar criar o aluguel"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(RentDTO model)
        {
            try
            {
                var result = await _rentService.Update(model);
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
                    Message = "Erro ao tentar atualizar o aluguel"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _rentService.Delete(id);
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
                    Message = "Erro ao tentar excluir o aluguel"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
