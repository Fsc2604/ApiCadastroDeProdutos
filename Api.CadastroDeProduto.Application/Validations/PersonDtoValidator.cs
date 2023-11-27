using Api.CadastroDeProduto.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.Validations
{
    public class PersonDtoValidator : AbstractValidator<PersonDto>
    {
        public PersonDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name deve ser informado");

            RuleFor(x => x.Document)
               .NotEmpty()
               .NotNull()
               .WithMessage("Document deve ser informado");

            RuleFor(x => x.Phone)
               .NotEmpty()
               .NotNull()
               .WithMessage("Phone deve ser informado");
        }
    }
}
