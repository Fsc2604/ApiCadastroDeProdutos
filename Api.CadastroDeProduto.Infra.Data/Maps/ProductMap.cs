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
            builder.ToTable("Produto");

            // Chave primária
            builder.HasKey(x => x.Id);

            //Colunas da tabela

            builder.Property(x => x.Id)
          .HasColumnName("IdProduto")
          .UseIdentityColumn();

            builder.Property(x => x.CodErp)
            .HasColumnName("CodErp");

            builder.Property(x => x.Name)
            .HasColumnName("Nome");

            builder.Property(x => x.Price)
            .HasColumnName("Preco");

            // Mapeamento/Relacionamento chave primária com chave estrangeira
            // Uma produto pode estar em várias  compras mas uma compra pode ter somente um respectivo produto 
            // 1 pra N
            builder.HasMany(c => c.Purchases)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);
        }

      
    }
}
