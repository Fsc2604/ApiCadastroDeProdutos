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
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            //Nome da tabela no banco
            builder.ToTable("Compra");

            // Chave primária
            builder.HasKey(x => x.Id);

            //Colunas da tabela

            builder.Property(x => x.Id)
          .HasColumnName("Idcompra")
          .UseIdentityColumn();

            builder.Property(x => x.PersonId)
            .HasColumnName("Idpessoa");

            builder.Property(x => x.ProductId)
            .HasColumnName("Idproduto");

            builder.Property(x => x.Date)
            .HasColumnName("Datacompra");

            // Mapeamento/Relacionamento chave primária com chave estrangeira
            // Uma compra só pode ter uma pessoa mas uma pessoa pode ter várias compras
            // N pra 1
            builder.HasOne(x => x.Person)
                .WithMany(p => p.Purchases);

            builder.HasOne(x => x.Product)
               .WithMany(p => p.Purchases);
        }


    }
}
