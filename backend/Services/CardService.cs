using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public interface ICardService
{
    Task<List<Card>> GetAllCardsAsync(int deckId);
    Task<Card?> GetCardAsync(int deckId, int cardId);
    Task CreateCardAsync(int deckId, Card card);
}

public class CardService : ICardService
{
    private readonly AppDbContext _context;

    public CardService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Card>> GetAllCardsAsync(int deckId)
    {
        var cards =  await _context.Cards.Where(c => c.DeckId == deckId).ToListAsync();
        return cards;
    }

    public async Task<Card?> GetCardAsync(int deckId, int cardId)
    {
        var card = await _context.Cards.Where(c => (c.DeckId == deckId && c.Id == cardId)).FirstOrDefaultAsync();
        return card;
    }

    public Task CreateCardAsync(int deckId, Card card)
    {
        card.DeckId = deckId;
        _context.Cards.Add(card);
        return _context.SaveChangesAsync();
    }
}