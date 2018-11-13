using System.Collections.Generic;
using System.Threading.Tasks;

using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Repositories;
using SppdDocs.Core.Services;

namespace SppdDocs.Infrastructure.Services
{
    internal class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<Card> GetCurrentAsync(string friendlyName)
        {
            return await _cardRepository.GetCurrentAsync(friendlyName);
        }

        public async Task<IEnumerable<string>> GetFriendlyNamesAsync()
        {
            return await _cardRepository.GetCurrentFriendlyNamesAsync();
        }
    }
}