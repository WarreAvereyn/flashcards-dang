using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services;

public interface IDeckService
{
    Task<List<Deck>> GetAllDecksAsync();
    Task<Deck?> GetDeckAsync(int id);
    Task<Deck?> CreateDeckAsync(Deck deck);
    Task<Deck?> UpdateDeckAsync(int id, Deck deck);
    Task<Deck?> DeleteDeckAsync(int id);
}

public class DeckService : IDeckService
{
    private readonly AppDbContext _context;

    public DeckService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Deck>> GetAllDecksAsync()
    {
        var decks =  await _context.Decks.ToListAsync();

        return decks;
    }

    public async Task<Deck?> GetDeckAsync(int id)
    {
        var deck = await _context.Decks.Where(d => d.Id == id).FirstOrDefaultAsync();
        return deck;
    }

    public async Task<Deck?> CreateDeckAsync(Deck deck)
    {
        deck.CreatedAt = DateTime.UtcNow;

        _context.Decks.Add(deck);
        await _context.SaveChangesAsync();

        return deck;
    }

    public async Task<Deck?> UpdateDeckAsync(int id, Deck deck)
    {
        var existingDeck = await _context.Decks.Where(d => d.Id == id).FirstOrDefaultAsync();
    
        if(existingDeck is null)
            return null;
        
        existingDeck.UpdatedAt = DateTime.UtcNow;
        existingDeck.Description = deck.Description;
        existingDeck.Name = deck.Name;

        await _context.SaveChangesAsync();

        return existingDeck;
    }

    public async Task<Deck?> DeleteDeckAsync(int id)
    {
        var existingDeck = await _context.Decks.Where(d => d.Id == id).FirstOrDefaultAsync();

        if(existingDeck is null)
            return null;
        
        _context.Decks.Remove(existingDeck);
        await _context.SaveChangesAsync();

        return existingDeck;
    } 
}