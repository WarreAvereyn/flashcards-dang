namespace backend.Models;
using System.Text.Json.Serialization;

public class Card
{
    public int Id { get; set; }
    public int DeckId { get; set; }
    public string Front { get; set; } = string.Empty;
    public string Back { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Deck? Deck { get; set; }
}