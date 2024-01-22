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
    public class PersonImageMap : IEntityTypeConfiguration<PersonImage>
    {
        public void Configure(EntityTypeBuilder<PersonImage> builder)
        {
            //Nome da tabela no banco
            builder.ToTable("pessoaimagem");

            // Chave primária
            builder.HasKey(x => x.Id);

            //Colunas da tabela

            builder.Property(x => x.Id)
                   .HasColumnName("idimagem")
                   .UseIdentityColumn();

            builder.Property(x => x.PersonId)
                   .HasColumnName("idpessoa");

            builder.Property(x => x.ImageBase)
                   .HasColumnName("imagembase");

            builder.Property(x => x.ImageUri)
                   .HasColumnName("imagemurl");

            // Uma Pessoa para muitas imagens
            // 1 pra N
            builder.HasOne(p => p.Person)
                   .WithMany(p => p.PersonImages);
            

        }
    }
}
