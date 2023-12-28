using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApiCadastroDeProduto.Domain.Repositories
{
    public interface IUnityOfWork : IDisposable
    {
        Task BeginTransaction();
        Task Commit();
        Task RollBack();
    }
}
