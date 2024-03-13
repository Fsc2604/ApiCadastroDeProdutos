using ApiCadastroDeProduto.Domain.Authentication;
using ApiCadastroDeProduto.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Infra.Data.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        public dynamic Generator(User user)
        {
            var permission = string.Join(",", user.UserPermissions.Select(x => x.Permission?.PermissionName));
            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim("Id", user.Id.ToString()),
                new Claim("Permissoes", permission)
            };

            var expires = DateTime.Now.AddDays(4);         

            // Criar um objeto SymmetricSecurityKey com a nova chave
            byte[] key = (Encoding.UTF8.GetBytes("CadastroDeProduto"));
            
            var keyReady = new SymmetricSecurityKey(key);
       
            var tokenData = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(keyReady,SecurityAlgorithms.HmacSha256Signature),
                expires: expires,
                claims: claims);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);
            return new
            {
                acess_token = token,
                expirations = expires
            };
        }
    }
}
