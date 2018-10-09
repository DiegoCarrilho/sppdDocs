using System;
using SppdDocs.Core.Domain.Enumerations;
using SppdDocs.Core.Domain.Interfaces;

namespace SppdDocs.Core.Utils.Extensions
{
	public static class LocalizedExtensions
	{
		public static T Value<T>(this ILocalized<T> localized, Language language)
			where T : class
		{
			switch (language)
			{
				case Language.En:
					return localized.En;
				case Language.Fr:
					return localized.Fr ?? localized.En;
				case Language.De:
					return localized.De ?? localized.En;
				case Language.It:
					return localized.It ?? localized.En;
				case Language.Ja:
					return localized.Ja ?? localized.En;
				case Language.Ko:
					return localized.Ko ?? localized.En;
				case Language.Ru:
					return localized.Ru ?? localized.En;
				case Language.Zh:
					return localized.Zh ?? localized.En;
				case Language.Pt:
					return localized.Pt ?? localized.En;
				case Language.Tr:
					return localized.Tr ?? localized.En;
				case Language.Pl:
					return localized.Pl ?? localized.En;
				default:
					throw new ArgumentOutOfRangeException(nameof(language), language, null);
			}
		}

		public static T? Value<T>(this ILocalized<T?> localized, Language language)
			where T : struct
		{
			switch (language)
			{
				case Language.En:
					return localized.En;
				case Language.Fr:
					return localized.Fr ?? localized.En;
				case Language.De:
					return localized.De ?? localized.En;
				case Language.It:
					return localized.It ?? localized.En;
				case Language.Ja:
					return localized.Ja ?? localized.En;
				case Language.Ko:
					return localized.Ko ?? localized.En;
				case Language.Ru:
					return localized.Ru ?? localized.En;
				case Language.Zh:
					return localized.Zh ?? localized.En;
				case Language.Pt:
					return localized.Pt ?? localized.En;
				case Language.Tr:
					return localized.Tr ?? localized.En;
				case Language.Pl:
					return localized.Pl ?? localized.En;
				default:
					throw new ArgumentOutOfRangeException(nameof(language), language, null);
			}
		}
	}
}