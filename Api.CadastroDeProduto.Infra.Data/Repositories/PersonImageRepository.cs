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
    public class PersonImageRepository : IPersonImageRepository
    {
        private readonly ConnectionDbContext _ConnectionDbContext;
        public PersonImageRepository(ConnectionDbContext connectionDbContext)
        {
            _ConnectionDbContext = connectionDbContext;
        }
        public async Task<PersonImage> CreateAsync(PersonImage personImage)
        {
            _ConnectionDbContext.Add(personImage);
            await _ConnectionDbContext.SaveChangesAsync();
            return personImage;
        }

        public async  Task EditAsync(PersonImage personImage)
        {
            _ConnectionDbContext.Update(personImage);
            await _ConnectionDbContext.SaveChangesAsync();
        }

        public async Task<PersonImage?> GetByIdAsync(int id)
        {
            return await _ConnectionDbContext.PersonImages.FirstOrDefaultAsync(x => x.Id == id);
        }

       
        public async Task<ICollection<PersonImage>> GetByPersonAsync(int personId)
        {
            //O EF nao mapeia a classe quando usa o AsNoTracking. Nao recomendado para usar em caso de edicao, pois pelo fato de nao mapear, ele vai criar novamente gerando uma duplicacao
            //Só use AsNoTracking quando o retorno nao for sofrer edicao,ou seja, quando for apenas pra trazer dados.
            //AsNoTracking deixa a consulta mais leve
            return await _ConnectionDbContext.PersonImages.AsNoTracking().Where(x => x.PersonId == personId).ToListAsync();
        }
    }
}
