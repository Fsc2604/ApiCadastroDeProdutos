using ApiCadastroDeProduto.Domain.Entities;
using ApiCadastroDeProduto.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Teste.Domain.Entities
{
    public class ProductTest
    {
        [Fact(DisplayName = "Não deve criar um produto sem nome")]
        public void CriaProduto_Product_NaoCriaProdutoSemNome()
        {
            var ex = Assert.Throws<DomainValidationException>(() =>
                     new Product( null,  "2464", 20));

            Assert.Equal("Nome deve ser informado", ex.Message);
        }

        [Fact(DisplayName = "Não deve criar um produto sem codErp")]
        public void CriaProduto_Product_NaoCriaProdutoSemCodigoErp()
        {
            var ex = Assert.Throws<DomainValidationException>(() =>
                     new Product("Teste Produto", null, 20));

            Assert.Equal("CodErp deve ser informado", ex.Message);
        }

        [Fact(DisplayName = "Deve criar Produto sem id")]
        public void CriaProduto_Product_DeveCriarProdutoSemId()
        {
            var product = new Product("Teste produto", "4647", 50);
            Assert.NotNull(product);
        }

        [Fact(DisplayName = "Nâo Deve criar Produto sem id")]
        public void CriaProduto_Product_NaoDeveCriarProdutoSemId()
        {
            var ex = Assert.Throws<DomainValidationException>(() =>
                     new Product(0, "Teste produto", "4647", 50));
            Assert.Equal("Id deve ser maior que zero", ex.Message);
        }

        [Fact(DisplayName = " Deve criar Produto com id")]
        public void CriaProduto_Product_DeveCriarProdutoComId()
        {
            var product = new Product(3, "Teste produto", "4647", 50);
            Assert.NotNull(product);
        }

    }
}
