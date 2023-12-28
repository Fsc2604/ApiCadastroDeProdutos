using Api.CadastroDeProduto.Infra.Data.Context;
using ApiCadastroDeProduto.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Infra.Data.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly ConnectionDbContext _ConnectionDbContext;
        private IDbContextTransaction _transaction;

        public UnityOfWork(ConnectionDbContext connectionDbContext)
        {
            _ConnectionDbContext = connectionDbContext;
        }
        public async Task BeginTransaction()
        {
            _transaction = await _ConnectionDbContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task RollBack()
        {
            await _transaction.RollbackAsync();
        }
        public void Dispose()
        {
            _transaction?.Dispose();
        }
    }
}
