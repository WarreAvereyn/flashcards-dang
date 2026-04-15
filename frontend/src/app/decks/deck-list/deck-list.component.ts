import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { DeckService } from '../../services/deck.service';
import { Deck } from '../../models/deck.model';

@Component({
  selector: 'app-deck-list',
  imports: [RouterLink],
  templateUrl: './deck-list.component.html',
})
export class DeckListComponent implements OnInit {
  decks: Deck[] = [];
  error = '';

  constructor(private deckService: DeckService) {}

  ngOnInit(): void {
    this.deckService.getAll().subscribe({
      next: decks => (this.decks = decks),
      error: () => (this.error = 'Failed to load decks.'),
    });
  }

  delete(id: number): void {
    if (!confirm('Delete this deck?')) return;
    this.deckService.delete(id).subscribe({
      next: () => (this.decks = this.decks.filter(d => d.id !== id)),
      error: () => (this.error = 'Failed to delete deck.'),
    });
  }
}
