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
        
        if (cards == null)
            return NotFound();

        return Ok(cards);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int deckId, int id)
    {
        var card = await _cardService.GetCardAsync(deckId, id);
        
        if (card == null)
            return NotFound();
        
        return Ok(card);
    }

    [HttpPost]
    public async Task<IActionResult> Create(int deckId, [FromBody] Card card)
    {
        if (card == null)
        {
            return BadRequest();
        }

        var created = await _cardService.CreateCardAsync(deckId, card);
        
        if (created == null)
            return NotFound();

        return CreatedAtAction(nameof(GetById), new { deckId = created.DeckId, id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int deckId, int id, [FromBody] Card card)
    {
        if (card == null)
        {
            return BadRequest();
        }

        var updated = await _cardService.UpdateCardAsync(deckId, id, card);

        if (updated == null)
            return NotFound();

        return Ok(updated);
    }
}
