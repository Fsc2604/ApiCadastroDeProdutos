using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCadastroDeProduto.Domain.Validations
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string error): base(error)
        {

        }

        public static void When(bool hasError, string Message)
        {
            if(hasError)
                throw new DomainValidationException(Message);
        }

      
    }
}
