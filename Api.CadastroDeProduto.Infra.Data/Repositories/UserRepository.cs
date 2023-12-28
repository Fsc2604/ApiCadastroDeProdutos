using Api.CadastroDeProduto.Infra.Data.Context;
using ApiCadastroDeProduto.Domain.Entities;
using ApiCadastroDeProduto.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionDbContext _connectionDbContext;

        public UserRepository(ConnectionDbContext connectionDbContext)
        {
            _connectionDbContext = connectionDbContext;
        }
        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _connectionDbContext.User.FirstOrDefaultAsync(x => x.Email == email && x.PassWord == password);
        }
    }
}
