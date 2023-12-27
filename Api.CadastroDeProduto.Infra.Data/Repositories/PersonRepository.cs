using Api.CadastroDeProduto.Infra.Data.Context;
using ApiCadastroDeProduto.Domain.Entities;
using ApiCadastroDeProduto.Domain.FiltersDB;
using ApiCadastroDeProduto.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ConnectionDbContext _ConnectionDbContext;
        public PersonRepository(ConnectionDbContext connectionDbContext)
        {
            _ConnectionDbContext = connectionDbContext;
        }
        public async Task<Person> CreateAsync(Person person)
        {
            _ConnectionDbContext.Add(person);
            await _ConnectionDbContext.SaveChangesAsync();
            return person;
        }
                            
        public async Task DeleteAsync(Person person)
        {
            _ConnectionDbContext.Remove(person);
            await _ConnectionDbContext.SaveChangesAsync();
        }
        public async Task EditAsync(Person person)
        {
            _ConnectionDbContext.Update(person);
            await _ConnectionDbContext.SaveChangesAsync();

        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _ConnectionDbContext.People.FirstOrDefaultAsync(x => x.Id == id);
        }
        /// <summary> Informa o documento da pessoa e retorna o Id. Útil para localizar clientes mais rapido</summary>
        public async Task<int> GetIdByDocumentAsync(string document)
        {
            return (await _ConnectionDbContext.People.FirstOrDefaultAsync(x => x.Document == document))?.Id ?? 0;
        }

        //<summary>Método para paginação</summary> 

        public async Task<PagedBaseResponse<Person>> GetPagedAsync(PersonFilterDB request)
        {
            var people = _ConnectionDbContext.People.AsQueryable();
            if(!string.IsNullOrEmpty(request.Name))
                people = people.Where(x=> x.Name.Contains(request.Name));

            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseResponse<Person>, Person>(people, request);

        }

        public async Task<ICollection<Person>> GetPeopleAsync()
        {
            return await _ConnectionDbContext.People.ToListAsync();
        }

       

       
    }
}
