import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'decks', pathMatch: 'full' },
  {
    path: 'decks',
    loadComponent: () =>
      import('./decks/deck-list/deck-list.component').then(m => m.DeckListComponent),
  },
  {
    path: 'decks/new',
    loadComponent: () =>
      import('./decks/deck-form/deck-form.component').then(m => m.DeckFormComponent),
  },
  {
    path: 'decks/:id',
    loadComponent: () =>
      import('./decks/deck-detail/deck-detail.component').then(m => m.DeckDetailComponent),
  },
  {
    path: 'decks/:id/edit',
    loadComponent: () =>
      import('./decks/deck-form/deck-form.component').then(m => m.DeckFormComponent),
  },
  {
    path: 'decks/:id/cards/new',
    loadComponent: () =>
      import('./cards/card-form/card-form.component').then(m => m.CardFormComponent),
  },
  {
    path: 'decks/:id/cards/:cardId/edit',
    loadComponent: () =>
      import('./cards/card-form/card-form.component').then(m => m.CardFormComponent),
  },
  {
    path: 'decks/:id/study',
    loadComponent: () =>
      import('./study/study.component').then(m => m.StudyComponent),
  },
];
