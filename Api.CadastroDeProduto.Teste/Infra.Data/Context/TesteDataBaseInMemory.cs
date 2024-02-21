using Api.CadastroDeProduto.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Teste.Infra.Data.Context
{
    public class TesteDataBaseInMemory
    {
        public  static ConnectionDbContext GetDatabase()
        {
            var name = Guid.NewGuid().ToString();
            return GetDatabase(name);
        }

        private static ConnectionDbContext GetDatabase(string name)
        {
            var inMemoryOption = new DbContextOptionsBuilder<ConnectionDbContext>()
                                 .UseInMemoryDatabase(name).Options;

            return new ConnectionDbContext(inMemoryOption);
        }
    }
}
