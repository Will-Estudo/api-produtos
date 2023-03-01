using ApiProdutos.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade produto
    /// </summary>
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO");
            
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID");

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.Preco)
                .HasColumnName("PRECO")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(c => c.Quantidade)
                .HasColumnName("QUANTIDADE")
                .IsRequired();

            builder.Property(c => c.DataHoraCadastro)
                .HasColumnName("DATAHORACADASTRO")
                .IsRequired();

            //mapeamento do relacionamento 1:N e FK
            builder.HasOne(p => p.Categoria) // Produto tem 1 categoria
                .WithMany(c => c.Produtos) // Categoria tem N produtos
                .HasForeignKey(p => p.IdCategoria); // FK
        }
    }
}
