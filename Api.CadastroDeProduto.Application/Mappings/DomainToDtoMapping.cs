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
        }
    }
}
