import { Component, OnInit,  ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { CardService } from '../services/card.service';
import { DeckService } from '../services/deck.service';
import { Card } from '../models/card.model';
import { Deck } from '../models/deck.model';

@Component({
  selector: 'app-study',
  imports: [RouterLink],
  templateUrl: './study.component.html',
})
export class StudyComponent implements OnInit {
  deck: Deck | null = null;
  cards: Card[] = [];
  currentIndex = 0;
  flipped = false;
  error = '';
  done = false;

  get current(): Card | null {
    return this.cards[this.currentIndex] ?? null;
  }

  get progress(): string {
    return `${this.currentIndex + 1} / ${this.cards.length}`;
  }

  constructor(
    private route: ActivatedRoute,
    private deckService: DeckService,
    private cardService: CardService,
  ) {}

  ngOnInit(): void {
    const deckId = +this.route.snapshot.paramMap.get('id')!;
    this.deckService.getById(deckId).subscribe({
      next: deck => (this.deck = deck),
      error: () => (this.error = 'Failed to load deck.'),
    });
    this.cardService.getAll(deckId).subscribe({
      next: cards => {
        this.cards = cards;
        if (cards.length === 0) this.done = true;
      },
      error: () => (this.error = 'Failed to load cards.'),
    });
  }

  flip(): void {
    this.flipped = !this.flipped;
  }

  next(): void {
    if (this.currentIndex < this.cards.length - 1) {
      this.currentIndex++;
      this.flipped = false;
    } else {
      this.done = true;
    }
  }

  prev(): void {
    if (this.currentIndex > 0) {
      this.currentIndex--;
      this.flipped = false;
    }
  }

  restart(): void {
    this.currentIndex = 0;
    this.flipped = false;
    this.done = false;
  }

  submit(text: string): void {
    if (text === this.current?.back) {
      alert('Correct!');
    } else {
      alert(`Incorrect! The correct answer was: ${this.current?.back}`);
    }
    this.next();
  }

  @ViewChild('answerInput') answerInput!: ElementRef<HTMLInputElement>;

  insert_character(char: string): void {
    const input = this.answerInput.nativeElement;
    const start = input.selectionStart ?? input.value.length;
    const end = input.selectionEnd ?? input.value.length;
    input.value = input.value.slice(0, start) + char + input.value.slice(end);
    input.setSelectionRange(start + 1, start + 1);
    input.focus();
  }
}
