using System;
using System.Threading.Tasks;

using SppdDocs.Core.Domain.Entities;

namespace SppdDocs.Core.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<TEntity> GetAsync(Guid id);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);
    }
}