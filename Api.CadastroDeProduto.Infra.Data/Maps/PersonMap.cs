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
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public  void Configure(EntityTypeBuilder<Person> builder)
        {
            //Nome da tabela no banco
            builder.ToTable("pessoa");

            // Chave primária
            builder.HasKey(x => x.Id);

            //Colunas da tabela

             builder.Property(x => x.Id)
           .HasColumnName("idpessoa")
           .UseIdentityColumn();

            builder.Property(x => x.Document)
            .HasColumnName("documento");

            builder.Property(x => x.Name)
            .HasColumnName("nome");

            builder.Property(x => x.Phone)
            .HasColumnName("celular");

            // Mapeamento/Relacionamento chave primária com chave estrangeira
            // Uma pessoa pode ter uma lista de compras mas uma compra é referentea a uma pessoa
            // 1 pra N
            builder.HasMany(c => c.Purchases)
                .WithOne(p => p.Person)
                .HasForeignKey(p => p.PersonId);
        }
    }
}
