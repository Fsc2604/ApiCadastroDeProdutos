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
    public class UserMap : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Nome da tabela no banco
            builder.ToTable("usuario");

            // Chave primária
            builder.HasKey(u => u.Id);

            //Colunas da tabela

            builder.Property(u => u.Id)
            .HasColumnName("idusuario");
              
            builder.Property(u => u.Email)
            .HasColumnName("email");

            builder.Property(u => u.Password)
            .HasColumnName("senha");
            
        }
    }
}