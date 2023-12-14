using Api.CadastroDeProduto.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {

        public ProductDtoValidator()
        {
            RuleFor(x => x.CodErp)
                .NotEmpty()
                .NotNull()
                .WithMessage("Coderp deve ser informado");

            RuleFor(x => x.Name)
               .NotEmpty()
               .NotNull()
               .WithMessage("Name deve ser informado");

            RuleFor(x => x.Price)
               .GreaterThan(0)
               .WithMessage("Price deve ser informado");
        }
    }
}

