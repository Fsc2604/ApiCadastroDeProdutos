using Api.CadastroDeProduto.Application.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Teste.Service
{
    public class BaseTest
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(OperatingSystem =>
            {
                OperatingSystem.AddProfile<DomainToDtoMapping>();
                OperatingSystem.AddProfile<DtoToDomainMapping>();
            });

            return config.CreateMapper();
        }
    }
}
