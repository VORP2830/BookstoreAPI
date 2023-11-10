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
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _personService.GetAll();
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
                    Message = "Erro ao tentar obter a lista de pessoas"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _personService.GetById(id);
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
                    Message = "Erro ao tentar obter a pessoa"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonDTO model)
        {
            try
            {
                var result = await _personService.Create(model);
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
                    Message = "Erro ao tentar criar a pessoa"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(PersonDTO model)
        {
            try
            {
                var result = await _personService.Update(model);
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
                    Message = "Erro ao tentar atualizar a pessoa"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _personService.Delete(id);
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
                    Message = "Erro ao tentar excluir a pessoa"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
