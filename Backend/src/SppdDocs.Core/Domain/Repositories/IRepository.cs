using System.Collections.Generic;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Domain.Specifications;

namespace SppdDocs.Core.Domain.Repositories
{
	public interface IRepository<TEntity> where TEntity : BaseEntity
	{
		TEntity GetById(int id);

		TEntity GetSingleBySpec(ISpecification<TEntity> spec);

		IEnumerable<TEntity> ListAll();

		IEnumerable<TEntity> List(ISpecification<TEntity> spec);

		TEntity Add(TEntity entity);

		void Update(TEntity entity);

		void Delete(TEntity entity);
	}
}