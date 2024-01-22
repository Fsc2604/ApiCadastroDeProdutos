using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCadastroDeProduto.Domain.Integrations
{
    public interface ISavePersonImage
    {
         string Save(string imageBase64);
    }
}
