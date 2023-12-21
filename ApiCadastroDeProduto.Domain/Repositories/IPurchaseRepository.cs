using ApiCadastroDeProduto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCadastroDeProduto.Domain.Repositories
{
    public interface IPurchaseRepository
    {
        //Assinatura dos métodos

        //Pega a Compra pelo Id
        Task<Purchase> GetByIdAsync(int id);

        //Pega uma lista de Compras
        Task<ICollection<Purchase>> GetAllAsync();

        //Cria uma Compra
        Task<Purchase> CreateAsync(Purchase purchase);

        //Edita uma Compra
        Task EditAsync(Purchase purchase);

        //Deleta uma Compra
        Task DeleteAsync(Purchase purchase);
    }
}
