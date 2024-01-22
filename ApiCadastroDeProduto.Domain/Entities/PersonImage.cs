using ApiCadastroDeProduto.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCadastroDeProduto.Domain.Entities
{
    public class PersonImage
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string ImageUri { get; set; }
        public string? ImageBase { get; set; }
        public Person Person { get; set; }

        public PersonImage(int personId, string? imageUri, string? imageBase)
        {
            Validation(personId);
            ImageUri = imageUri;
            ImageBase = imageBase;
        }

        private void Validation(int personId)
        {
            DomainValidationException.When(personId == 0, "Idpessoa deve ser informado");
            PersonId = personId;

           
        }
    }

    
}
