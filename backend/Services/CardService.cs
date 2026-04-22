using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services;

public interface ICardService
{
    Task<List<Card>?> GetAllCardsAsync(int deckId);
    Task<Card?> GetCardAsync(int deckId, int cardId);
    Task<Card?> CreateCardAsync(int deckId, Card card);
    Task<Card?> UpdateCardAsync(int deckId, int cardId, Card card);
    Task<Card?> DeleteCardAsync(int deckId, int cardId);
}

public class CardService : ICardService
{
    private readonly AppDbContext _context;

    public CardService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Card>?> GetAllCardsAsync(int deckId)
    {
        var deckExists = await _context.Decks.AnyAsync(d => d.Id == deckId);
        if (!deckExists)
            return null;

        var cards =  await _context.Cards.Where(c => c.DeckId == deckId).OrderBy(c => c.CreatedAt).ToListAsync();
        return cards;
    }

    public async Task<Card?> GetCardAsync(int deckId, int cardId)
    {
        var card = await _context.Cards.Where(c => c.DeckId == deckId && c.Id == cardId).FirstOrDefaultAsync();
        return card;
    }

    public async Task<Card?> CreateCardAsync(int deckId, Card card)
    {
        var deckExists = await _context.Decks.AnyAsync(d => d.Id == deckId);
        if (!deckExists)
            return null;

        card.DeckId = deckId;
        card.CreatedAt = DateTime.UtcNow;
        _context.Cards.Add(card);
        await _context.SaveChangesAsync();

        return card;
    }

    public async Task<Card?> UpdateCardAsync(int deckId, int cardId, Card card)
    {
        var existingCard = await _context.Cards
            .FirstOrDefaultAsync(c => c.DeckId == deckId && c.Id == cardId);

        if (existingCard == null)
            return null;

        var targetDeckId = card.DeckId != 0 ? card.DeckId : deckId;

        if (targetDeckId != deckId)
        {
            var targetDeckExists = await _context.Decks.AnyAsync(d => d.Id == targetDeckId);
            if (!targetDeckExists)
                return null;
        }

        existingCard.DeckId = targetDeckId;
        existingCard.Front = card.Front;
        existingCard.Back = card.Back;
        existingCard.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return existingCard;
    }

    public async Task<Card?> DeleteCardAsync(int deckId, int cardId)
    {
        var existingCard = await _context.Cards
            .FirstOrDefaultAsync(c => c.DeckId == deckId && c.Id == cardId);

        if (existingCard == null)
            return null;

        _context.Cards.Remove(existingCard);
        await _context.SaveChangesAsync();

        return existingCard;
    }
}