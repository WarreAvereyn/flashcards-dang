import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CardService } from '../../services/card.service';

@Component({
  selector: 'app-card-form',
  imports: [FormsModule, RouterLink],
  templateUrl: './card-form.component.html',
})
export class CardFormComponent implements OnInit {
  deckId!: number;
  cardId: number | null = null;
  front = '';
  back = '';
  error = '';
  submitting = false;

  get isEdit(): boolean {
    return this.cardId !== null;
  }

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private cardService: CardService,
  ) {}

  ngOnInit(): void {
    this.deckId = +this.route.snapshot.paramMap.get('id')!;
    const cardId = this.route.snapshot.paramMap.get('cardId');
    if (cardId) {
      this.cardId = +cardId;
      this.cardService.getById(this.deckId, this.cardId).subscribe({
        next: card => {
          this.front = card.front;
          this.back = card.back;
        },
        error: () => (this.error = 'Failed to load card.'),
      });
    }
  }

  submit(): void {
    if (!this.front.trim() || !this.back.trim()) {
      this.error = 'Front and back are required.';
      return;
    }
    this.submitting = true;
    const payload = { front: this.front.trim(), back: this.back.trim() };
    const request = this.isEdit
      ? this.cardService.update(this.deckId, this.cardId!, payload)
      : this.cardService.create(this.deckId, payload);

    request.subscribe({
      next: () => this.router.navigate(['/decks', this.deckId]),
      error: () => {
        this.error = 'Failed to save card.';
        this.submitting = false;
      },
    });
  }
}
