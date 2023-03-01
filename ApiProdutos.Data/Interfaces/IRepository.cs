using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Data.Interfaces
{
    /// <summary>
    /// Interface genérica para implementação dos repositórios
    /// </summary>
    /// <typeparam name="TEntity">Representa a entidade/tipo</typeparam>
    public interface IRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
}
