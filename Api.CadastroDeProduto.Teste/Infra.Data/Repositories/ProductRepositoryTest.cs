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
    public class ProductRepositoryTest
    {
        private ConnectionDbContext _context;

        [Fact(DisplayName = "Deve criar um produto")]

        public async Task Salva_CreateAsync_DevesSalvarUmProdutoNoBancoDeDados()
        {
            var product = new Product("teste produto", "87888", 10m);
            _context = TesteDataBaseInMemory.GetDatabase();

            var productRepository = new ProductRepository(_context);
            await productRepository.CreateAsync(product);

            var productResult = _context.Product.FirstOrDefault();
            Assert.Equal(product.Name, productResult.Name);
        }

        [Fact(DisplayName = "Deve listar um produto pelo seu Id")]

        public async Task LitaProduto_ProductRepopsitory_DeveBuscarUmProdutoPeloSeuId()
        {
            var product = new Product("teste produto", "87888", 10m);
            _context = TesteDataBaseInMemory.GetDatabase();
            _context.Product.Add(product);
            _context.SaveChanges();

            var productRepository = new ProductRepository(_context);
            var productResult = await productRepository.GetByIdAsync(product.Id);

           
            Assert.Equal(product.Name, productResult.Name);
        }

        [Fact(DisplayName = "Deve Editar um produto ")]

        public async Task EditaProduto_ProductRepopsitory_DeveEditarUmproduto()
        {
            var product = new Product("teste produto", "87888", 10m);
            _context = TesteDataBaseInMemory.GetDatabase();
            _context.Product.Add(product);
            _context.SaveChanges();

            product.Edita("teste 2 produto", "8788", 10m);

            var productRepository = new ProductRepository(_context);
            await productRepository.EditAsync(product);

            var productResult = _context.Product.FirstOrDefault(); 
            Assert.Equal("teste 2 produto", productResult.Name);
        }

        [Fact(DisplayName = "Deve Remover um produto ")]
        public async Task DeletaProduto_ProductRepopsitory_DeveDeletarUmproduto()
        {
            var product = new Product("teste produto", "87888", 10m);
            _context = TesteDataBaseInMemory.GetDatabase();
            _context.Product.Add(product);
            _context.SaveChanges();


            var productRepository = new ProductRepository(_context);
            await productRepository.DeleteAsync(product);

        
            Assert.Equal(0, _context.Product.Count());
        }


    }
}
