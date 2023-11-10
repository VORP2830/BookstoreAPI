using Bookstore.API.Extensions;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDTO model)
        {
            try
            {
                var result = await _userService.Register(model);
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
                    Message = "Erro ao tentar registrar"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDTO model)
        {
            try
            {
                var result = await _userService.Login(model);
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
                    Message = "Erro ao tentar fazer login"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(UserDTO model)
        {
            try
            {
                var result = await _userService.Update(model, User.GetUserId());
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
                    Message = "Erro ao tentar atualizar usuário"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _userService.Get(User.GetUserId());
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
                    Message = "Erro ao tentar pegar usuário"
                };
                return this.StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}