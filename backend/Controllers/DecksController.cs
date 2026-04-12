using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("decks")]
public class DecksController : ControllerBase
{
    private readonly IDeckService _deckService;
    public DecksController(IDeckService deckService)
    {
        _deckService = deckService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var decks = await _deckService.GetAllDecksAsync();
        return Ok(decks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var deck = await _deckService.GetDeckAsync(id);
        
        if (deck == null)
            return NotFound();
        
        return Ok(deck);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Deck deck)
    {
        if (deck == null)
        {
            return BadRequest();
        }

        var created = await _deckService.CreateDeckAsync(deck);
        
        if (created == null)
            return NotFound();

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Deck deck)
    {
        if (deck == null)
            return BadRequest();

        var updated = await _deckService.UpdateDeckAsync(id, deck);

        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _deckService.DeleteDeckAsync(id);

        if (deleted == null)
            return NotFound();

        return NoContent();
    }
}