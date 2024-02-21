using Api.CadastroDeProduto.Infra.Data.Context;
using Api.CadastroDeProduto.Infra.Data.Repositories;
using Api.CadastroDeProduto.Teste.Infra.Data.Context;
using ApiCadastroDeProduto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Teste.Infra.Data.Repositories
{
    public class PersonRepositoryTest
    {
        private ConnectionDbContext _context;

        [Fact(DisplayName = "Deve criar uma pessoa")]

        public async Task  Salva_CreateAsync_DevesSalvarUmaPessoaNoBancoDeDados()
        {
            var person = new Person("15484545", "Testde de unidade", "4785621");
            _context = TesteDataBaseInMemory.GetDatabase();

           var personRepository = new PersonRepository(_context);
           await personRepository.CreateAsync(person);

            var result = _context.People.FirstOrDefault();
            Assert.Equal(person.Document, result.Document);
        }

        [Fact(DisplayName =  "Deve retornar pessoa pelo seu ID")]

        public async Task ListaPessoa_GetByIdAsync_DeveRetornarAPesssoaPeloSeuId()
        {
            var person = new Person("15484545", "Testde de unidade", "4785621");
            _context = TesteDataBaseInMemory.GetDatabase();
            _context.People.Add(person);
            _context.SaveChanges();

            var personRepository = new PersonRepository(_context);
            var result = await personRepository.GetByIdAsync(1);

            Assert.Equal(person.Document, result.Document);

        }
    }
}
