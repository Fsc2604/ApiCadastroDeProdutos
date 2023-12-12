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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Nome da tabela no banco
            builder.ToTable("produto");

            // Chave primária
            builder.HasKey(x => x.Id);

            //Colunas da tabela

            builder.Property(x => x.Id)
          .HasColumnName("idproduto")
          .UseIdentityColumn();

            builder.Property(x => x.CodErp)
            .HasColumnName("coderp");

            builder.Property(x => x.Name)
            .HasColumnName("nome");

            builder.Property(x => x.Price)
            .HasColumnName("preco");

            // Mapeamento/Relacionamento chave primária com chave estrangeira
            // Uma produto pode estar em várias  compras mas uma compra pode ter somente um respectivo produto 
            // 1 pra N
            builder.HasMany(c => c.Purchases)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);
        }

      
    }
}
