namespace SppdDocs.Core.Domain.Entities
{
	public class NamedEntity : VersionedEntity
	{
		public string Name { get; set; }

		public byte[] Image { get; set; }
	}
}