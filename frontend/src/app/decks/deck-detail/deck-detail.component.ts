import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { DeckService } from '../../services/deck.service';
import { CardService } from '../../services/card.service';
import { Deck } from '../../models/deck.model';
import { Card } from '../../models/card.model';

@Component({
  selector: 'app-deck-detail',
  imports: [RouterLink],
  templateUrl: './deck-detail.component.html',
})
export class DeckDetailComponent implements OnInit {
  deck: Deck | null = null;
  cards: Card[] = [];
  error = '';
  deckId!: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private deckService: DeckService,
    private cardService: CardService,
  ) {}

  ngOnInit(): void {
    this.deckId = +this.route.snapshot.paramMap.get('id')!;
    this.deckService.getById(this.deckId).subscribe({
      next: deck => (this.deck = deck),
      error: () => (this.error = 'Failed to load deck.'),
    });
    this.cardService.getAll(this.deckId).subscribe({
      next: cards => (this.cards = cards),
      error: () => (this.error = 'Failed to load cards.'),
    });
  }

  deleteDeck(): void {
    if (!confirm('Delete this deck and all its cards?')) return;
    this.deckService.delete(this.deckId).subscribe({
      next: () => this.router.navigate(['/decks']),
      error: () => (this.error = 'Failed to delete deck.'),
    });
  }

  deleteCard(cardId: number): void {
    if (!confirm('Delete this card?')) return;
    this.cardService.delete(this.deckId, cardId).subscribe({
      next: () => (this.cards = this.cards.filter(c => c.id !== cardId)),
      error: () => (this.error = 'Failed to delete card.'),
    });
  }
}
