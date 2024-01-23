using ApiCadastroDeProduto.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCadastroDeProduto.Domain.Entities
{
    public sealed  class UserPermission
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int PermissionId { get; private set; }

        public User User { get;  set; }
        public Permission Permission { get;  set; }

        public UserPermission(int userId, int permissionId)
        {
            Validation(userId, permissionId);
        }

        private void Validation(int userId, int permissionId)
        {
            DomainValidationException.When(userId == 0, "Id usuário visual deve ser informado");
            DomainValidationException.When(permissionId == 0, "Id permissão deve ser informado");

            UserId = userId;
            PermissionId = permissionId;
        }
    }
}
