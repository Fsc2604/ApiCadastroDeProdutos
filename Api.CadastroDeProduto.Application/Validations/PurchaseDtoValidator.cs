using Api.CadastroDeProduto.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.Validations
{
    public class PurchaseDtoValidator : AbstractValidator<PurchaseDto>
    {
        public PurchaseDtoValidator()
        {
            RuleFor(x => x.CodErp)
                .NotEmpty()
                .NotNull()
                .WithMessage("Coderp deve ser informado");

            RuleFor(x => x.Document)
               .NotEmpty()
               .NotNull()
               .WithMessage("Document deve ser informado");
        }
    }
}