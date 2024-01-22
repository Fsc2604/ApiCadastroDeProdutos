using ApiCadastroDeProduto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCadastroDeProduto.Domain.Repositories
{
    public interface IPersonImageRepository
    {
        Task<PersonImage?> GetByIdAsync(int id);
        Task<PersonImage> CreateAsync(PersonImage personImage);
        Task<ICollection<PersonImage>> GetByPersonAsync(int PersonId);
        Task EditAsync(PersonImage personImage);
    }
}
