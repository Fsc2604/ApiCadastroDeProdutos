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
            builder.ToTable("Pessoa");

            // Chave primária
            builder.HasKey(x => x.Id);

            //Colunas da tabela

             builder.Property(x => x.Id)
           .HasColumnName("Idpessoa")
           .UseIdentityColumn();

            builder.Property(x => x.Document)
            .HasColumnName("Documento");

            builder.Property(x => x.Name)
            .HasColumnName("Nome");

            builder.Property(x => x.Phone)
            .HasColumnName("Celular");

            // Mapeamento/Relacionamento chave primária com chave estrangeira
            // Uma pessoa pode ter uma lista de compras mas uma compra é referentea a uma pessoa
            // 1 pra N
            builder.HasMany(c => c.Purchases)
                .WithOne(p => p.Person)
                .HasForeignKey(p => p.PersonId);
        }
    }
}
