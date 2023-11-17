using ApiCadastroDeProduto.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCadastroDeProduto.Domain.Entities
{
   public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal? Price { get; private set; }

        /// <summary> Construtor para adição de uma pessoa  </summary>
        public Product(string name, string codErp, decimal price)
        {
            Validation(name, codErp, price);
        }

        /// <summary> Construtor para edição de uma pessoa </summary>
        public Product(int id, string name, string codErp, decimal price)
        {
            DomainValidationException.When(id <= 0, "Id deve ser maior que zero");
            Id = id;

            Validation(name, codErp, price);
        }

        /// <summary> Método para validação caso algum atributo esteja vazio < /summary>
        private void Validation(string name, string codErp, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado");
            DomainValidationException.When(string.IsNullOrEmpty(codErp), "CodErp deve ser informado");
            DomainValidationException.When(price < 0, "Preço deve ser informado");

            Name = name;
            CodErp = codErp;
            Price = price;
        }
    }
}
