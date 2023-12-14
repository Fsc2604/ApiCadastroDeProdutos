using ApiCadastroDeProduto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCadastroDeProduto.Domain.Repositories
{
    public interface IProductRepository
    {

        //Assinatura dos métodos

        //Pega Produto pelo Id
        Task<Product> GetByIdAsync(int id);

        //Pega uma lista de Produtos
        Task<ICollection<Product>> GetProductAsync();

        //Cria um Produto
        Task<Product> CreateAsync(Product product);

        //Edita um Produto
        Task EditAsync(Product product);

        //Deleta um Produto
        Task DeleteAsync(Product product);

        Task<int> GetIdByCodErpAsync(string codErp);
    }
}

