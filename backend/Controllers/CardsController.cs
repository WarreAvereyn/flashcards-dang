using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("decks/{deckId}/cards")]
public class CardsController : ControllerBase
{
    private readonly ICardService _cardService;

    public CardsController(ICardService cardService)
    {
        _cardService = cardService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int deckId)
    {
        var cards = await _cardService.GetAllCardsAsync(deckId);
        return Ok(cards);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int deckId, int id)
    {
        var card = await _cardService.GetCardAsync(deckId, id);
        return Ok(card);
    }

    [HttpPost]
    public async Task<IActionResult> Create(int deckId, [FromBody] Card card)
    {
        if (card == null)
        {
            return BadRequest();
        }
        await _cardService.CreateCardAsync(deckId, card);
        return CreatedAtAction(nameof(GetById), new { deckId = card.DeckId, id = card.Id }, card);
    }


}
