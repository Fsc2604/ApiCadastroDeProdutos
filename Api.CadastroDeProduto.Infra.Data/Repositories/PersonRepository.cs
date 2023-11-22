using Api.CadastroDeProduto.Infra.Data.Context;
using ApiCadastroDeProduto.Domain.Entities;
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

        public async Task<ICollection<Person>> GetPeopleAsync()
        {
            return await _ConnectionDbContext.People.ToListAsync();
        }

       

       
    }
}
