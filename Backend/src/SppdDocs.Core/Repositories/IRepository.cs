using System;
using System.Collections.Generic;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Specifications;

namespace SppdDocs.Core.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        TEntity GetById(Guid id);

        TEntity GetSingleBySpec(ISpecification<TEntity> spec);

        IEnumerable<TEntity> ListAll();

        IEnumerable<TEntity> List(ISpecification<TEntity> spec);

        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}