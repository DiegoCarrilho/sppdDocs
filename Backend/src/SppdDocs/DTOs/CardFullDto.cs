namespace SppdDocs.DTOs
{
	public class CardFullDto : VersionedEntityDto
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public string RarityName { get; set; }

		public string ClassName { get; set; }
	}
}