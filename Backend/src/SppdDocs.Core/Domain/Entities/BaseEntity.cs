using System;

namespace SppdDocs.Core.Domain.Entities
{
	public abstract class BaseEntity
	{
		protected BaseEntity()
		{
			Id = Guid.NewGuid();
		}

		/// <summary>
		///     Unique identifier identifying a single instance of an entity
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		///     Specifies when the entity instance has been created
		/// </summary>
		public DateTime CreatedOnUtc { get; set; }

		///// <summary>
		/////     Specifies by whom the entity instance has been created
		///// </summary>
		//public ApplicationUser CreatedBy { get; set; }

		///// <summary>
		/////     EF FK referencing the <see cref="ApplicationUser" /> having created the entity instance
		///// </summary>
		//public Guid CreatedById { get; set; }

		/// <summary>
		///     Validates this instance. Called before persisting an entity
		/// </summary>
		public virtual void Validate()
		{
		}
	}
}