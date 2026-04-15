import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { DeckService } from '../../services/deck.service';

@Component({
  selector: 'app-deck-form',
  imports: [FormsModule, RouterLink],
  templateUrl: './deck-form.component.html',
})
export class DeckFormComponent implements OnInit {
  deckId: number | null = null;
  name = '';
  description = '';
  error = '';
  submitting = false;

  get isEdit(): boolean {
    return this.deckId !== null;
  }

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private deckService: DeckService,
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.deckId = +id;
      this.deckService.getById(this.deckId).subscribe({
        next: deck => {
          this.name = deck.name;
          this.description = deck.description;
        },
        error: () => (this.error = 'Failed to load deck.'),
      });
    }
  }

  submit(): void {
    if (!this.name.trim()) {
      this.error = 'Name is required.';
      return;
    }
    this.submitting = true;
    const payload = { name: this.name.trim(), description: this.description.trim() };
    const request = this.isEdit
      ? this.deckService.update(this.deckId!, payload)
      : this.deckService.create(payload);

    request.subscribe({
      next: deck => this.router.navigate(['/decks', deck.id]),
      error: () => {
        this.error = 'Failed to save deck.';
        this.submitting = false;
      },
    });
  }
}
