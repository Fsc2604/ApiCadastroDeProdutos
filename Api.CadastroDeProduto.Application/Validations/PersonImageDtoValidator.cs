using Api.CadastroDeProduto.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.Validations
{
    public class PersonImageDtoValidator : AbstractValidator<PersonImageDto>
    {

        public PersonImageDtoValidator()
        {
            RuleFor(x => x.PersonId)
              .GreaterThanOrEqualTo(0)
              .WithMessage("PersonId não pode ser menor ou igual a zero");

            RuleFor(x => x.Image)
               .NotEmpty()
               .NotNull()
               .WithMessage("Image deve ser informado");

        }
    }
}
