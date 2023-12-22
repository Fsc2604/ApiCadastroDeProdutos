using Api.CadastroDeProduto.Application.DTOs;
using ApiCadastroDeProduto.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            /// <summary>Classe responsável por fazer a conversão de entidade para dto </summary>
            CreateMap<Person, PersonDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Purchase, PurchaseDetailDto>()
                .ForMember(x => x.Person, opt => opt.Ignore())
                .ForMember(x =>x.Product, opt => opt.Ignore())
                .ConstructUsing((model, context) =>
                {
                    var dto = new PurchaseDetailDto
                    {
                        Product = model.Product.Name,
                        Id = model.Product.Id,
                        Date = model.Date,
                        Person = model.Person.Name
                    };
                    return dto;
                });
        }
    }
}
