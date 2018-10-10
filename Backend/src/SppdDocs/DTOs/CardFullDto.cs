namespace SppdDocs.DTOs
{
	public class CardFullDto : VersionedEntityDto
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public int EnergyCost { get; set; }

		public double? Range { get; set; }

		public int UnlockedAtRank { get; set; }

		public string ThemeName { get; set; }

		public string RarityName { get; set; }

		public string ClassName { get; set; }

		public string EffectName { get; set; }

		public string StatusEffectName { get; set; }
	}
}