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
    public class ProductRepository : IProductRepository
    {
        private readonly ConnectionDbContext _ConnectionDbContext ;

        public ProductRepository(ConnectionDbContext connectionDbContext)
        {
            _ConnectionDbContext = connectionDbContext;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            _ConnectionDbContext.Add(product);
            await _ConnectionDbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            _ConnectionDbContext.Remove(product);
            await _ConnectionDbContext.SaveChangesAsync();
            
        }

        public async Task EditAsync(Product product)
        {
            _ConnectionDbContext.Update(product);
            await _ConnectionDbContext.SaveChangesAsync();
            
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _ConnectionDbContext.Product.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Product>> GetProductAsync()
        {
            return await _ConnectionDbContext.Product.ToListAsync();
        }
    }
}