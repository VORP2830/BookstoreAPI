using AutoMapper;
using BCryptNet = BCrypt.Net;
using Bookstore.Application.DTOs;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Exceptions;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        public UserService(IMapper mapper, IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }
        public async Task<UserDTO> Get(long userId)
        {
            User user = await _unitOfWork.UserRepository.GetById(userId);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<object> Login(UserLoginDTO model)
        {
            User userLogin = await _unitOfWork.UserRepository.GetByUserName(model.UserName);
            bool isSuccess = false;
            if (userLogin != null && userLogin.Active == true)
            {
                isSuccess = BCryptNet.BCrypt.Verify(model.Password, userLogin.Password);
            }
            if (!isSuccess)
            {
                throw new BookstoreException("Usuário ou senha incorretos");
            }
            if(isSuccess)
            {
                var token = await _tokenService.GenerateToken(userLogin.Id, userLogin.UserName);
                return new {
                        name = userLogin.Name,
                        token = token
                };
            }
            throw new BookstoreException("Usuário ou senha incorretos");
        }
        public async Task<object> Register(UserDTO model)
        {
            User userLogin = await _unitOfWork.UserRepository.GetByUserName(model.UserName);
            if(userLogin != null)
            {
                throw new BookstoreException("O nome de usuário já está em uso");
            }
            User user = _mapper.Map<User>(model);
            user.SetPassword(BCryptNet.BCrypt.HashPassword(model.Password));
            user.SetActive(true);
            _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
            var token = await _tokenService.GenerateToken(user.Id, user.UserName);
            return new {
                    name = user.Name,
                    token = token
            };
        }
        public async Task<UserDTO> Update(UserDTO model, long userId)
        {
            if(userId != model.Id)
            {
                throw new BookstoreException("Você não tem autorização para modificar as informações de outro usuário");
            }
            User user = await _unitOfWork.UserRepository.GetById(model.Id);
            if(model.UserName != user.UserName)
            {
                throw new BookstoreException("Não é possível alterar o nome de usuário");
            }
            if(string.IsNullOrEmpty(model.Password))
            {
                model.Password = user.Password;
            }
            else
            {
                model.Password = BCryptNet.BCrypt.HashPassword(model.Password);
            }
            _mapper.Map(user, model);
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            user.SetPassword(null);
            return _mapper.Map<UserDTO>(user);
        }
    }
}