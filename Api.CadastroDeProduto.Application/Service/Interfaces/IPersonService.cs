using Api.CadastroDeProduto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.Service.Interfaces
{
    public interface IPersonService
    {
        //Criar uma pessoa
        Task<ResultService<PersonDto>> CreateAsync(PersonDto personDTO);

        //Listar todas a pessoas
        Task<ResultService<ICollection<PersonDto>>> GetAsync();
        
        //Listar somente uma pessoa
        Task<ResultService<PersonDto>> GetByIdAsync(int id);
        
        //Edita uma pessoa
        Task<ResultService> UpdateAsync(PersonDto personDTO);
        
        //Deleta  uma pessoa
        Task<ResultService> DeleteAsync(int id);
    }
}
