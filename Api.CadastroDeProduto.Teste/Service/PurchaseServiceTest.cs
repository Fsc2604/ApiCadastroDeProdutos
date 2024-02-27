using Api.CadastroDeProduto.Application.DTOs;
using Api.CadastroDeProduto.Application.Service;
using ApiCadastroDeProduto.Domain.Entities;
using ApiCadastroDeProduto.Domain.Repositories;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Teste.Service
{
    public class PurchaseServiceTest
    {
        [Fact(DisplayName = "Deve criar uma compra")]
        public async Task Salvar_CreateAsync_DeveSalvarUmaCompra()
        {
            var dto = new PurchaseDto
            {
                CodErp = "321",
                Document = "123456789",
                Price = 10,
                ProductName = "test"
            };

            var mocker = new AutoMocker();
            mocker.GetMock<IProductRepository>().Setup(x => x.GetIdByCodErpAsync("321")).ReturnsAsync(1);

            mocker.GetMock<IPersonRepository>().Setup(x => x.GetIdByDocumentAsync("123456789")).ReturnsAsync(1);

            mocker.GetMock<IPurchaseRepository>().Setup(x => x.CreateAsync(It.IsAny<Purchase>())).ReturnsAsync(new Purchase(1, 1));

            var purchaseService = mocker.CreateInstance<PurchaseService>();
            var result = await purchaseService.CreateAsync(dto);

            Assert.NotNull(result);
            Assert.True(result.IsSucess);
            mocker.GetMock<IPurchaseRepository>()
                  .Verify(x => x.CreateAsync(It.IsAny<Purchase>()), Times.Once);
        }

        [Fact (DisplayName ="Deve deletar uma compra")]

        public async Task Remove_RemoveAsync_DeveDeletarUmaCompra()
        {
            var mocker = new AutoMocker();
            mocker.GetMock<IPurchaseRepository>().Setup(x => x.GetByIdAsync(1))
                                                 .ReturnsAsync(new Purchase (1,1));
            var purchaseService = mocker.CreateInstance<PurchaseService>();
            
            var result = await purchaseService.RemoveAsync(1);


            Assert.NotNull(result);
            Assert.True(result.IsSucess);

            mocker.GetMock<IPurchaseRepository>()
                  .Verify(x => x.DeleteAsync(It.IsAny<Purchase>()), Times.Once);
        }
    }
}
