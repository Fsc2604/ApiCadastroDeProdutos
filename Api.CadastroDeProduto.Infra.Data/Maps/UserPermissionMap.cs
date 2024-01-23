using ApiCadastroDeProduto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Infra.Data.Maps
{
    public class UserPermissionMap : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            //Nome da tabela no banco
            builder.ToTable("permissaousuario");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Colunas da Tabela
            builder.Property(x => x.Id)
                   .HasColumnName("idpermissaousuario")
                   .UseIdentityColumn();

            builder.Property(x => x.PermissionId)
                   .HasColumnName("idpermissao");


            builder.Property(x => x.UserId)
                   .HasColumnName("idusuario");


            //1 pra N
            builder.HasOne(x => x.Permission)
                   .WithMany(u => u.UserPermissions);


            //1 pra N
            builder.HasOne(x => x.User)
                   .WithMany(p => p.UserPermissions);
        }
    }
    
}
