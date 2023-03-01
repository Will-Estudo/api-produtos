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
    /// Repositório de dados para categoria
    /// </summary>
    public class CategoriaRepository : IRepository<Categoria>
    {
        public void Add(Categoria entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Categorias.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Categoria entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Categorias.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public List<Categoria> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Categorias
                    .OrderBy(c => c.Nome)
                    .ToList();
            }
        }

        public Categoria GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Categorias
                    .Where(c => c.Id == id)
                    .FirstOrDefault();
            }
        }

        public void Update(Categoria entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }
    }
}
