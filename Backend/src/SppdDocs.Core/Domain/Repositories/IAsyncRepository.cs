using System.Collections.Generic;
using System.Threading.Tasks;
using SppdDocs.Core.Domain.Entities;

namespace SppdDocs.Core.Domain.Repositories
{
	public interface IAsyncRepository<T> where T : BaseEntity
	{
		Task<T> GetByIdAsync(int id);
		Task<List<T>> ListAllAsync();
		Task<T> AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}