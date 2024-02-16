using ApiCadastroDeProduto.Domain.Entities;
using ApiCadastroDeProduto.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Teste.Domain.Entities
{
    public class PurchaseTest
    {
        [Fact(DisplayName = "Não deve criar compra sem o id produto")]
        public void CriaCompra_Purchase_NaoCriaCompraSemIdProduto()
        {
            var ex = Assert.Throws<DomainValidationException>(() => new Purchase(0, 2));
            Assert.Equal("Id Produto deve ser informado", ex.Message);
        }

        [Fact(DisplayName = "Não deve criar compra sem o id pessoa")]
        public void CriaCompra_Purchase_NaoCriaCompraSemIdPessoa()
        {
            var ex = Assert.Throws<DomainValidationException>(() => new Purchase(1, 0));
            Assert.Equal("Id Pessoa deve ser informado", ex.Message);
        }

        [Fact(DisplayName = "Deve criar compra sem Id")]
        public void CriaCompra_Purchase_CriaCompraSemId()
        {
            var purchase = new Purchase(2, 1);
            Assert.NotNull(purchase);
        }

        [Fact(DisplayName = "Deve criar compra com Id")]
        public void CriaCompra_Purchase_CriaCompraComId()
        {
            var purchase = new Purchase(1,2, 1);
            Assert.NotNull(purchase);
        }

        [Fact(DisplayName = "Deve Editar compra ")]
        public void EditaCompra_Edit_EditarUmaCompra()
        {
            var purchase = new Purchase(1, 2, 1);
            purchase.Edit(1, 3, 4);
            Assert.Equal(3, purchase.ProductId);
            Assert.Equal(4, purchase.PersonId);
        }
    }
}
