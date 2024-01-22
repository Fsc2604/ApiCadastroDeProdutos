using ApiCadastroDeProduto.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCadastroDeProduto.Domain.Entities
{
   public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
       
        // Uma pessoa pode  ter mais de uma compra
        public ICollection<Purchase> Purchases { get; private set; }
        public ICollection<PersonImage> PersonImages { get; private set; }

        /// <summary> Construtor para adição de uma pessoa  </summary>
        public Person(string name, string document, string phone)
        {
            Validation(name, document, phone);
            Purchases  = new List<Purchase>();
            PersonImages = new List<PersonImage>();
        }

        /// <summary> Construtor para edição de uma pessoa </summary>
        public Person(int id, string name, string document,string phone)
        {
           
            DomainValidationException.When(id <= 0, "Id deve ser maior que zero");
            Id = id;

            Validation(name, document, phone);
            Purchases = new List<Purchase>();
            PersonImages =  new List <PersonImage>();

        }
        /// <summary> Método para validação caso algum atributo esteja vazio < /summary>
        private void Validation(string name, string document, string phone)
        {
            DomainValidationException.When(string.IsNullOrWhiteSpace(name), "Nome deve ser informado");
            DomainValidationException.When(string.IsNullOrWhiteSpace(document), "Documento deve ser informado");
            DomainValidationException.When(string.IsNullOrWhiteSpace(phone), "Celular deve ser informado");

            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}
