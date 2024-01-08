using Api.CadastroDeProduto.Application.DTOs;
using Api.CadastroDeProduto.Application.Service.Interfaces;
using Api.CadastroDeProduto.Application.Validations;
using ApiCadastroDeProduto.Domain.Authentication;
using ApiCadastroDeProduto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
        }
        public async Task<ResultService<dynamic>> GenerateTokenAsync(UserDto userDto)
        {
            if (userDto == null)
                return ResultService.Fail<dynamic>("Objeto deve ser informado");

            var validator = new UserDtoValidator().Validate(userDto);
            if (!validator.IsValid)
                return ResultService.RequestError<dynamic>("Problemas com a validacão", validator);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(userDto.Email, userDto.Password);
            if (user == null)
                return ResultService.Fail<dynamic> ("Usuário ou Senha não encontrado!");

            return ResultService.Ok(_tokenGenerator.Generator(user));
        }
    }
}
