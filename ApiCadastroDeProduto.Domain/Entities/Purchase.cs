using ApiCadastroDeProduto.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCadastroDeProduto.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; private set; }
        public Product Product { get; private set; }

        /// <summary> Construtor para adição de uma compra  </summary>
        public Purchase(int productId, int personId)
        {
            Validation(productId, personId);
        }

        /// <summary> Construtor para edição de uma compra </summary>
        public Purchase(int id, int productId, int personId)
        {
            DomainValidationException.When(Id <= 0, "Id deve ser maior que zero");
            Id = id;

            Validation(productId, personId);
       
        }

        public void Edit(int id, int productId, int personId)
        {
            DomainValidationException.When(Id <= 0, "Id deve ser maior que zero");
            Id = id;

            Validation(productId, personId);

        }

        /// <summary> Método para validação caso algum atributo esteja vazio < /summary>
        private void Validation(int productId, int personId)
        {
            DomainValidationException.When(productId <= 0, "Id Produto deve ser informado");
            DomainValidationException.When(personId <= 0, "Id Pessoa deve ser informado");
            //DomainValidationException.When(!date.HasValue, "Data da compra deve ser informado");

            ProductId = productId;
            PersonId = personId;
            Date = DateTime.Now;
        }
    }
}
