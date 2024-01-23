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
    public class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {  
            //Nome da tabela no banco
            builder.ToTable("permissao");

            //Chave primária
            builder.HasKey(x => x.Id);

            //Colunas da Tabela
            builder.Property(x => x.Id)
                   .HasColumnName("idpermissao")
                   .UseIdentityColumn();

            builder.Property(x => x.VisualName)
                   .HasColumnName("nomevisual");


            builder.Property(x => x.PermissionName)
                   .HasColumnName("nomepermissao");

        
            //N pra 1
            builder.HasMany(x => x.UserPermissions)
                   .WithOne(p => p.Permission)
                   .HasForeignKey(p => p.PermissionId);
        }
    }
}
