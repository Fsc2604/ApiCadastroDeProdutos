using Api.CadastroDeProduto.Infra.Data.Repositories;
using ApiCadastroDeProduto.Domain.Entities;
using ApiCadastroDeProduto.Domain.FiltersDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCadastroDeProduto.Domain.Repositories
{
    public interface IPersonRepository
    {
        //Assinatura dos métodos

        //Pega Pessoa pelo Id
        Task<Person> GetByIdAsync(int id);

        //Pega uma lista de Pessoas
        Task<ICollection<Person>> GetPeopleAsync();
       
        //Cria uma Pessoa
        Task<Person> CreateAsync(Person person);
        
        //Edita uma Pessoa
        Task EditAsync(Person person);
        
        //Deleta uma Pessoa
        Task DeleteAsync(Person person);

        Task<int> GetIdByDocumentAsync(string document);

        //Método que busca dados paginados
        Task<PagedBaseResponse<Person>> GetPagedAsync(PersonFilterDB request);
    }
}
