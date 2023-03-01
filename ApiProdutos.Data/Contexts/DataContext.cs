using ApiProdutos.Data.Entities;
using ApiProdutos.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Data.Contexts
{
    /// <summary>
    /// Classe para conexão com BD via EF
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Config string de conexão com BD
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_ApiProdutos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");            
        }

        /// <summary>
        /// Adicionar classes de mapeamento
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());            
        }

        /// <summary>
        /// Propriedade para fornecer métodos de CRUD para categoria
        /// </summary>
        public DbSet<Categoria> Categorias { get; set; }

        /// <summary>
        /// Propriedade para fornecer métodos de CRUD para produto
        /// </summary>
        public DbSet<Produto> Produtos { get; set; }
    }
}
