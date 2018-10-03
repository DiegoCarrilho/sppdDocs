using System;
using System.Collections.Generic;
using System.Linq;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Domain.Repositories;
using SppdDocs.Core.Services;

namespace SppdDocs.Infrastructure.Services
{
	internal class CardService : ICardService
	{
		private readonly IRepositoryVersioned<Card> _cardRepository;

		public CardService(IRepositoryVersioned<Card> cardRepository)
		{
			_cardRepository = cardRepository;
		}

		public Card GetCurrent(Guid cardId)
		{
			return _cardRepository.GetCurrentByEntityId(cardId);
		}

		public IEnumerable<Card> GetAllCurrent()
		{
			return _cardRepository.GetAllCurrent().ToList();
		}
	}
}