using Api.CadastroDeProduto.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.Validations
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {

        public UserDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email deve ser informado");

            RuleFor(x => x.Password)
               .NotEmpty()
               .NotNull()
               .WithMessage("Password deve ser informado");
        }
    }
}