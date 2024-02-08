using ApiCadastroDeProduto.Domain.Entities;
using ApiCadastroDeProduto.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Teste.Domain.Entities
{
    public class PersonTest
    {
        [Fact(DisplayName = "Não deve criar pessoa sem documento")]
        public void CriaPessoa_Person_NaoCriaPessoaSemDocumento() 
        {
            var ex = Assert.Throws<DomainValidationException>(() =>
                     new Person(document: null, name: "Test", phone: "99999999"));    
            
            Assert.Equal("Documento deve ser informado", ex.Message);
        }

        [Fact(DisplayName = "Não deve criar pessoa sem id")]
        public void CriaPessoa_Person_NaoCriaPessoaSemId()
        {
            var ex = Assert.Throws<DomainValidationException>(() =>
                     new Person(id: 0, document: "6766676", name: "Test", phone: "99999999"));

            Assert.Equal("Id deve ser maior que zero", ex.Message);
        }

        [Fact(DisplayName = "Deve criar Pessoa")]
        public void CriaPessoa_Person_DeveCriarPessoa()
        {
            var person = new Person("6766676",  "Test",  "99999999");
            Assert.NotNull(person);
        }

    }
}
