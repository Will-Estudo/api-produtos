using ApiProdutos.Data.Contexts;
using ApiProdutos.Data.Entities;
using ApiProdutos.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Data.Repositories
{
    /// <summary>
    /// Repositório de dados para produto
    /// </summary>
    public class ProdutoRepository : IRepository<Produto>
    {
        public void Add(Produto entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Produtos.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Produto entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Produtos.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public List<Produto> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Produtos
                    .Include(p => p.Categoria)
                    .OrderBy(p => p.Nome)
                    .ToList();
            }
        }

        public Produto GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Produtos
                    .Include(p => p.Categoria)
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }

        public void Update(Produto entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }
    }
}
