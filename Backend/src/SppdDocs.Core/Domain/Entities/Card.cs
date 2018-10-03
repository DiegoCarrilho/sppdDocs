namespace SppdDocs.Core.Domain.Entities
{
	public class Card : VersionedEntity
	{
		public string Name { get; set; }

		public string Description { get; set; }
	}
}