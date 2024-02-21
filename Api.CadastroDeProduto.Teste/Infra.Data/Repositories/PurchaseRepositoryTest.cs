using Api.CadastroDeProduto.Infra.Data.Context;
using Api.CadastroDeProduto.Infra.Data.Repositories;
using Api.CadastroDeProduto.Teste.Infra.Data.Context;
using ApiCadastroDeProduto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Teste.Infra.Data.Repositories
{
    public class PurchaseRepositoryTest
    {
        private ConnectionDbContext _context;

        [Fact(DisplayName = "Deve criar uma compra")]

        public async Task SalvarCompraDb_CreateAsync_DevesSalvarUmaCompraNoBancoDeDados()
        {
            var purchase = new Purchase(1,1);
            _context = TesteDataBaseInMemory.GetDatabase();

            var purchaseRepository = new PurchaseRepository(_context);
            await purchaseRepository.CreateAsync(purchase);

            var purchaseResult = _context.Purchase.FirstOrDefault();
            Assert.Equal(1,purchaseResult.PersonId);
        }
       

        [Fact(DisplayName = "Deve editar comppra")]

        public async Task EditaCompra_EditAsync_DevesEditarUmaCompraNoBancoDeDados()
        {
            var purchase = new Purchase(1,1);
            _context = TesteDataBaseInMemory.GetDatabase();
            _context.Add(purchase);
            _context.SaveChanges();

            purchase.Edit(1, 2, 3);

            var purchaseRepository = new PurchaseRepository(_context);
            await purchaseRepository.EditAsync(purchase);

            var purchaseResult = _context.Purchase.FirstOrDefault();
            Assert.Equal(3, purchaseResult.PersonId);
        }

        [Fact(DisplayName = "Deve retornar uma compra pelo seu ID")]

        public async Task RetornaCompra_GetByIdAsync_DeveRetornarUmaCompra()
        {
           //Testando os includes do repositório de compra
            var product = new Product("Teste produto", "564545",40m);
            var person = new Person("3776555565", "Teste Pessoa", "6783564545");

            _context = TesteDataBaseInMemory.GetDatabase();
            _context.Add(product);
            _context.Add(person);
            _context.SaveChanges();

            var purchase = new Purchase(1, 1);
            _context.Add(purchase);
            _context.SaveChanges();

            var purchaseRepository = new PurchaseRepository(_context);
            var purchaseResult = await purchaseRepository.GetByIdAsync(purchase.Id);

            Assert.Equal(1, purchaseResult.PersonId);
        }
    }
}
