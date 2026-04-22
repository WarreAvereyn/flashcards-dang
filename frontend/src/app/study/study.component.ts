import { Component, OnInit,  ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { NgClass } from '@angular/common';
import { CardService } from '../services/card.service';
import { DeckService } from '../services/deck.service';
import { Card } from '../models/card.model';
import { Deck } from '../models/deck.model';

@Component({
  selector: 'app-study',
  imports: [RouterLink, NgClass],
  templateUrl: './study.component.html',
})
export class StudyComponent implements OnInit {
  deck: Deck | null = null;
  cards: Card[] = [];
  currentIndex = 0;
  flipped = false;
  error = '';
  done = false;
  numberOfCards = 0;
  correctAnswers: Card[] = [];
  wrongAnswers: Card[] = [];
  feedbackState: 'correct' | 'wrong-first' | 'wrong-final' | null = null;

  get cardFeedbackClasses(): string {
    if (this.feedbackState === 'correct') return 'border-green-400 shadow-neo-correct';
    if (this.feedbackState === 'wrong-first') return 'border-yellow-400 shadow-neo-warn';
    if (this.feedbackState === 'wrong-final') return 'border-red-500 shadow-neo-error';
    return 'border-cinnamon-wood-300 dark:border-cinnamon-wood-600 shadow-neo-lg';
  }

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
        this.numberOfCards = cards.length;
        if (cards.length === 0) this.done = true;
      },
      error: () => (this.error = 'Failed to load cards.'),
    });
  }

  flip(): void {
    this.flipped = !this.flipped;
  }

  next(): void {
    this.feedbackState = null;
    if (this.currentIndex < this.cards.length - 1) {
      this.currentIndex++;
      this.flipped = false;
    } else {
      this.done = true;
    }
  }

  restart(): void {
    this.feedbackState = null;
    this.currentIndex = 0;
    this.flipped = false;
    this.done = false;
    this.correctAnswers = [];
    this.wrongAnswers = [];
    this.cards = this.cards.slice(0, this.numberOfCards);
  }

  submit(text: string): void {
    if (text === '' || text === null) {
      return;
    } 
    // First attempt
    if (this.currentIndex < this.numberOfCards) {
      if (text.trim().toLowerCase() === this.current?.back.trim().toLowerCase()) {
        this.markCorrect();
      } 
      else {
        this.markWrong(1);
      }
    }
    // Second attempt
    else{
      this.markWrong(2);
    }
  }

  markCorrect(): void {
    this.correctAnswers.push(this.current!);
    this.feedbackState = 'correct';
    this.flip();
    setTimeout(() => { this.feedbackState = null; this.next(); }, 1500);
  }

  markWrong(attempt: number): void {
    this.wrongAnswers.push(this.current!);
    const card = this.current!;
    this.feedbackState = attempt === 1 ? 'wrong-first' : 'wrong-final';
    this.flip();
    setTimeout(() => {
      if (attempt === 1) this.cards.push(card);
      this.feedbackState = null; 
      this.next(); 
    }, 1500);
  }    

  flipClick(): void {
    this.currentIndex < this.numberOfCards ? this.markWrong(1) : this.markWrong(2);
  }

  @ViewChild('answerInput') answerInput!: ElementRef<HTMLInputElement>;

  insertCharacter(char: string): void {
    const input = this.answerInput.nativeElement;
    const start = input.selectionStart ?? input.value.length;
    const end = input.selectionEnd ?? input.value.length;
    input.value = input.value.slice(0, start) + char + input.value.slice(end);
    input.setSelectionRange(start + 1, start + 1);
    input.focus();
  }
}
