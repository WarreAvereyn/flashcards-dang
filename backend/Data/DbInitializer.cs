using backend.Models;

namespace backend.Data;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (context.Decks.Any()) return; // Already seeded

        var now = DateTime.UtcNow;

        var deck1 = new Deck
        {
            Name = "Unidade 1",
            Description = "Portuguese vocabulary - Unit 1: Greetings, basics & everyday essentials",
            CreatedAt = now,
            UpdatedAt = now,
            Cards = new List<Card>
            {
                new Card { Front = "olá", Back = "hello", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "obrigado", Back = "thank you (male speaker)", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "obrigada", Back = "thank you (female speaker)", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "por favor", Back = "please", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "sim", Back = "yes", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "não", Back = "no", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "bom dia", Back = "good morning", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "boa tarde", Back = "good afternoon", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "boa noite", Back = "good evening / good night", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "adeus", Back = "goodbye", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "tchau", Back = "bye (informal)", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "desculpe", Back = "sorry / excuse me", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "com licença", Back = "excuse me (permission)", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "como está?", Back = "how are you? (formal)", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "como estás?", Back = "how are you? (informal)", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "bem", Back = "well / fine", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "mal", Back = "bad / poorly", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "eu", Back = "I", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "tu", Back = "you (informal)", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "você", Back = "you (formal)", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "ele", Back = "he", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "ela", Back = "she", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "nós", Back = "we", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "eles", Back = "they (masculine)", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "elas", Back = "they (feminine)", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o homem", Back = "the man", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a mulher", Back = "the woman", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o menino", Back = "the boy", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a menina", Back = "the girl", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a pessoa", Back = "the person", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o amigo", Back = "the friend (male)", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a amiga", Back = "the friend (female)", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a família", Back = "the family", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o nome", Back = "the name", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "como se chama?", Back = "what is your name?", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "chamo-me...", Back = "my name is...", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "prazer", Back = "pleasure (nice to meet you)", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a água", Back = "the water", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o café", Back = "the coffee", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o chá", Back = "the tea", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o pão", Back = "the bread", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a comida", Back = "the food", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "comer", Back = "to eat", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "beber", Back = "to drink", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "falar", Back = "to speak", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "ser", Back = "to be (permanent)", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "estar", Back = "to be (temporary)", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "ter", Back = "to have", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "ir", Back = "to go", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "vir", Back = "to come", CreatedAt = now, UpdatedAt = now },
            }
        };

        var deck2 = new Deck
        {
            Name = "Unidade 2",
            Description = "Portuguese vocabulary - Unit 2: Home, places & daily life",
            CreatedAt = now,
            UpdatedAt = now,
            Cards = new List<Card>
            {
                new Card { Front = "a casa", Back = "the house", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o apartamento", Back = "the apartment", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o quarto", Back = "the bedroom", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a cozinha", Back = "the kitchen", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a sala", Back = "the living room", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a casa de banho", Back = "the bathroom", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o jardim", Back = "the garden", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a porta", Back = "the door", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a janela", Back = "the window", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a mesa", Back = "the table", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a cadeira", Back = "the chair", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a cama", Back = "the bed", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a rua", Back = "the street", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a cidade", Back = "the city", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o país", Back = "the country", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a escola", Back = "the school", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o trabalho", Back = "the work / job", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o escritório", Back = "the office", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a loja", Back = "the shop", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o supermercado", Back = "the supermarket", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o restaurante", Back = "the restaurant", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o hospital", Back = "the hospital", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a farmácia", Back = "the pharmacy", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o banco", Back = "the bank", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "a estação", Back = "the station", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "o aeroporto", Back = "the airport", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "grande", Back = "big / large", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "pequeno", Back = "small", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "novo", Back = "new", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "velho", Back = "old", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "bonito", Back = "beautiful / handsome", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "feio", Back = "ugly", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "quente", Back = "hot", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "frio", Back = "cold", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "aberto", Back = "open", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "fechado", Back = "closed", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "perto", Back = "near / close", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "longe", Back = "far", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "aqui", Back = "here", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "ali", Back = "there", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "onde?", Back = "where?", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "quando?", Back = "when?", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "porquê?", Back = "why?", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "quanto?", Back = "how much?", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "morar", Back = "to live (reside)", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "trabalhar", Back = "to work", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "comprar", Back = "to buy", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "vender", Back = "to sell", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "abrir", Back = "to open", CreatedAt = now, UpdatedAt = now },
                new Card { Front = "fechar", Back = "to close", CreatedAt = now, UpdatedAt = now },
            }
        };

        context.Decks.AddRange(deck1, deck2);
        context.SaveChanges();
    }
}