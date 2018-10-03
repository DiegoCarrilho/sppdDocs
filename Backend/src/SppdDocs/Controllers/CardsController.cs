using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SppdDocs.Core.Services;
using SppdDocs.DTOs;

namespace SppdDocs.Controllers
{
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

		[HttpGet("{cardId}")]
		public ActionResult<CardFullDto> Get(Guid cardId)
		{
			return _mapper.Map<CardFullDto>(_cardService.GetCurrent(cardId));
		}

		[HttpGet]
		public IEnumerable<CardFullDto> GetAll()
		{
			return _mapper.Map<IEnumerable<CardFullDto>>(_cardService.GetAllCurrent());
		}
	}
}