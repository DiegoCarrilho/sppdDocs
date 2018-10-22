using System.Collections.Generic;

namespace SppdDocs.DTOs
{
	public class CardFullDto : VersionedDto
	{
		private IEnumerable<NamedDto> _attributes;
		private IEnumerable<CardUpgradeDto> _upgrades;

		public string Name { get; set; }

		public string DescriptionMarkdown { get; set; }

		public string DescriptionOnCard { get; set; }

		public int EnergyCost { get; set; }

		public double? Range { get; set; }

		public int UnlockedAtRank { get; set; }

		public string ThemeName { get; set; }

		public string RarityName { get; set; }

		public string ClassName { get; set; }

		public string EffectName { get; set; }

		public string StatusEffectName { get; set; }

		public IEnumerable<NamedDto> CardAttributes
		{
			get => _attributes ?? (_attributes = new List<NamedDto>());
			set => _attributes = value;
		}

		public IEnumerable<CardUpgradeDto> CardUpgrades
		{
			get => _upgrades ?? (_upgrades = new List<CardUpgradeDto>());
			set => _upgrades = value;
		}
	}
}