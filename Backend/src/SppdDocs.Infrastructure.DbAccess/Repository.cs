using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SppdDocs.Core.Entities;
using SppdDocs.Core.Interfaces;

namespace SppdDocs.Infrastructure.DbAccess
{
	/// <summary>
	///     "There's some repetition here - couldn't we have some the sync methods call the async?"
	///     https://blogs.msdn.microsoft.com/pfxteam/2012/04/13/should-i-expose-synchronous-wrappers-for-asynchronous-methods/
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Repository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
	{
		public Repository(Context dbContext)
		{
			DbContext = dbContext;
		}

		protected Context DbContext { get; }

		public virtual async Task<T> GetByIdAsync(int id)
		{
			return await DbContext.Set<T>().FindAsync(id);
		}

		public async Task<List<T>> ListAllAsync()
		{
			return await DbContext.Set<T>().ToListAsync();
		}

		public async Task<List<T>> ListAsync(ISpecification<T> spec)
		{
			// fetch a Queryable that includes all expression-based includes
			var queryableResultWithIncludes = spec.Includes
			                                      .Aggregate(DbContext.Set<T>().AsQueryable(),
				                                      (current, include) => current.Include(include));

			// modify the IQueryable to include any string-based include statements
			var secondaryResult = spec.IncludeStrings
			                          .Aggregate(queryableResultWithIncludes,
				                          (current, include) => current.Include(include));

			// return the result of the query using the specification's criteria expression
			return await secondaryResult
			             .Where(spec.Criteria)
			             .ToListAsync();
		}

		public async Task<T> AddAsync(T entity)
		{
			DbContext.Set<T>().Add(entity);
			await DbContext.SaveChangesAsync();

			return entity;
		}

		public async Task UpdateAsync(T entity)
		{
			DbContext.Entry(entity).State = EntityState.Modified;
			await DbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			DbContext.Set<T>().Remove(entity);
			await DbContext.SaveChangesAsync();
		}

		public virtual T GetById(int id)
		{
			return DbContext.Set<T>().Find(id);
		}

		public T GetSingleBySpec(ISpecification<T> spec)
		{
			return List(spec).FirstOrDefault();
		}

		public IEnumerable<T> ListAll()
		{
			return DbContext.Set<T>().AsEnumerable();
		}

		public IEnumerable<T> List(ISpecification<T> spec)
		{
			// fetch a Queryable that includes all expression-based includes
			var queryableResultWithIncludes = spec.Includes
			                                      .Aggregate(DbContext.Set<T>().AsQueryable(),
				                                      (current, include) => current.Include(include));

			// modify the IQueryable to include any string-based include statements
			var secondaryResult = spec.IncludeStrings
			                          .Aggregate(queryableResultWithIncludes,
				                          (current, include) => current.Include(include));

			// return the result of the query using the specification's criteria expression
			return secondaryResult
			       .Where(spec.Criteria)
			       .AsEnumerable();
		}

		public T Add(T entity)
		{
			DbContext.Set<T>().Add(entity);
			DbContext.SaveChanges();

			return entity;
		}

		public void Update(T entity)
		{
			DbContext.Entry(entity).State = EntityState.Modified;
			DbContext.SaveChanges();
		}

		public void Delete(T entity)
		{
			DbContext.Set<T>().Remove(entity);
			DbContext.SaveChanges();
		}
	}
}