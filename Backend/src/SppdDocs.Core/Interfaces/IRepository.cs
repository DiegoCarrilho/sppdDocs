using System.Collections.Generic;
using SppdDocs.Core.Entities;

namespace SppdDocs.Core.Interfaces
{
	public interface IRepository<T> where T : BaseEntity
	{
		T GetById(int id);
		T GetSingleBySpec(ISpecification<T> spec);
		IEnumerable<T> ListAll();
		IEnumerable<T> List(ISpecification<T> spec);
		T Add(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}