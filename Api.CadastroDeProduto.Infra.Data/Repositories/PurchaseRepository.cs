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
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ConnectionDbContext _ConnectionDbContext;
        public PurchaseRepository(ConnectionDbContext connectionDbContext)
        {
            _ConnectionDbContext = connectionDbContext;
        }
        public async Task<Purchase> CreateAsync(Purchase purchase)
        {
            _ConnectionDbContext.Add(purchase);
            await _ConnectionDbContext.SaveChangesAsync();
            return purchase;
        }    

        public async Task DeleteAsync(Purchase purchase)
        {
            _ConnectionDbContext.Remove(purchase);
            await _ConnectionDbContext.SaveChangesAsync();
        }

        public async Task EditAsync(Purchase purchase)
        {
            _ConnectionDbContext.Update(purchase);
            await _ConnectionDbContext.SaveChangesAsync();

        }

        public async Task<ICollection<Purchase>> GetAllAsync()
        {

            return await _ConnectionDbContext.Purchase
                 .Include(x => x.Person)
                 .Include(x => x.Product)
                 .ToListAsync();
        }

        public async Task<Purchase> GetByIdAsync(int id)
        {
            return await _ConnectionDbContext.Purchase
                .Include(x => x.Person)
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Purchase>> GetByPersonIdAsync(int personId)
        {
            return await _ConnectionDbContext.Purchase
                .Include(x => x.Person)
                .Include(x => x.Product)
                .Where(x => x.PersonId == personId).ToListAsync();
        }

        public async Task<ICollection<Purchase>> GetByProductIdAsync(int productId)
        {
            return await _ConnectionDbContext.Purchase
                .Include(x => x.Product)
                .Include(x => x.Person)
                .Where(x => x.ProductId == productId).ToListAsync();
        }
    }
}
