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
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            /// <summary>Classe responsável por fazer a conversão de dto e para entidade </summary>
            CreateMap<PersonDto, Person>();
            CreateMap<ProductDto, Product>();
        }
    }
}
