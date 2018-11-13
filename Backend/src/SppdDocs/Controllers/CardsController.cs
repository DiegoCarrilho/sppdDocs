using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Services;
using SppdDocs.DTOs;

namespace SppdDocs.Controllers
{
    /// <summary>
    ///     Controller exposing the API available for <see cref="Card" />s.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController
    {
        private readonly ICardService _cardService;
        private readonly IMapper _mapper;

        public CardsController(ICardService cardService, IMapper mapper)
        {
            _cardService = cardService;
            _mapper = mapper;
        }

        [HttpGet("{friendlyName}")]
        public async Task<CardFullDto> Get(string friendlyName)
        {
            return _mapper.Map<CardFullDto>(await _cardService.GetCurrentAsync(friendlyName));
        }

        [HttpGet("FriendlyNames")]
        public async Task<IEnumerable<string>> GetFriendlyNames()
        {
            return await _cardService.GetFriendlyNamesAsync();
        }
    }
}