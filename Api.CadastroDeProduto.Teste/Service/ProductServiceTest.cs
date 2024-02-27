using Api.CadastroDeProduto.Application.DTOs;
using Api.CadastroDeProduto.Application.Service;
using Api.CadastroDeProduto.Infra.Data.Repositories;
using ApiCadastroDeProduto.Domain.Entities;
using ApiCadastroDeProduto.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Teste.Service
{
    public class ProductServiceTest
    {
        private ProductService _productService;

        private Mock<IProductRepository> _productRepository;

        [Fact(DisplayName = "Deve criar um produto")]

        public async Task Salvar_CreateAsync_DeveCriarUmProduto()
        {

            var dto = new ProductDto()
            {
                Name = "Coca-Cola",
                Id = 1,
                CodErp = "14256",
                Price = 14
            };

            _productRepository = new Mock<IProductRepository>();
            _productRepository.Setup(x => x.CreateAsync(It.IsAny<Product>()))
                              .ReturnsAsync(It.IsAny<Product>());

            _productService = new ProductService(_productRepository.Object, new BaseTest().GetMapper());
            var result = await _productService.CreateAsync(dto);
            Assert.NotNull(result);
            Assert.True(result.IsSucess);

            _productRepository.Verify(x => x.CreateAsync(It.IsAny<Product>()), Times.Once());
        }

        [Fact(DisplayName = "Não Deve criar um produto com objeto null")]
        public async Task NaoSalva_CreateAsync_NaoDeveCriarProdutoComObjetoNull()
        {

            ProductDto dto = null;
           

            _productRepository = new Mock<IProductRepository>();
         

            _productService = new ProductService(_productRepository.Object, new BaseTest().GetMapper());
            var result = await _productService.CreateAsync(dto);
            Assert.False(result.IsSucess);
            Assert.Equal("Objeto Deve ser informado!", result.Message);

         
        }


        [Fact(DisplayName = "Deve editar um produto")]

        public async Task Edita_UpdateAsync_DeveEditarUmProduto()
        {

            var dto = new ProductDto()
            {
                Name = "Coca-Cola",
                Id = 1,
                CodErp = "14256",
                Price = 14
            };

            _productRepository = new Mock<IProductRepository>();
            
            var product = new Product("Agua", "546487", 4);

            _productRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                              .ReturnsAsync(product);

            _productRepository.Setup(x => x.EditAsync(It.IsAny<Product>())).Returns(Task.CompletedTask);
            _productService = new ProductService(_productRepository.Object, new BaseTest().GetMapper());
            var result = await _productService.UpdateAsync(dto);
            Assert.NotNull(result);
            Assert.True(result.IsSucess);

            _productRepository.Verify(x => x.EditAsync(It.IsAny<Product>()), Times.Once());

            Assert.Equal("Coca-Cola", product.Name);
        }
    }
}
