using Api.CadastroDeProduto.Application.DTOs;
using Api.CadastroDeProduto.Application.Service;
using ApiCadastroDeProduto.Domain.Entities;
using ApiCadastroDeProduto.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Teste.Service
{
    public class PersonServiceTest
    {
        private Mock<IPersonRepository> _personRepository;

        private PersonService _personService;

        [Fact(DisplayName = "Deve criar uma pessoa")]

        public async Task Salvar_CreateAsync_DeveSalvarUmaPessoa()
        {

            var dto = new PersonDto()
            {
                Document = "6557",
                Name = "nome pessoa test",
                Phone = "67676878",
                Id = 1
            };

            _personRepository  = new Mock<IPersonRepository>();
            _personRepository.Setup(x=> x.CreateAsync(It.IsAny<Person>()))
                              .ReturnsAsync(It.IsAny<Person>());

            _personService = new PersonService(_personRepository.Object, new BaseTest().GetMapper());
            var result = await _personService.CreateAsync(dto);
            Assert.NotNull(result);
            Assert.True(result.IsSucess);

            _personRepository.Verify(x => x.CreateAsync(It.IsAny<Person>()), Times.Once());
        }

        [Fact(DisplayName = "Deve criar pessoa sem objeto")]

        public async Task NaoCriaPessoa_CreateAsync_NaoDeveSalvarPessoaComObjetoNulo()
        {

            PersonDto dto = null;
            

            _personRepository = new Mock<IPersonRepository>();
            

            _personService = new PersonService(_personRepository.Object, new BaseTest().GetMapper());
            var result = await _personService.CreateAsync(dto);
            Assert.NotNull(result);
            Assert.False(result.IsSucess);
            Assert.Equal("Objeto deve ser informado", result.Message);
           
        }
    }
}
