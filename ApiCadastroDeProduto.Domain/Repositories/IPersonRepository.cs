using ApiCadastroDeProduto.Domain.Entities;
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

        //Pega uma lista dde Pessoas
        Task<ICollection<Person>> GetPeopleAsync();
       
        //Cria uma Pessoa
        Task<Person> CreateAsync(Person person);
        
        //Editauma Pessoa
        Task<Person> EditAsync(Person person);
        
        //Deleta uma Pessoa
        Task<Person> DeleteAsync(Person person);
    }
}
