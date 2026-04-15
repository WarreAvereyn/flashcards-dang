import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Card, CardCreate } from '../models/card.model';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class CardService {
  private base(deckId: number) {
    return `${environment.apiUrl}/decks/${deckId}/cards`;
  }

  constructor(private http: HttpClient) {}

  getAll(deckId: number): Observable<Card[]> {
    return this.http.get<Card[]>(this.base(deckId));
  }

  getById(deckId: number, cardId: number): Observable<Card> {
    return this.http.get<Card>(`${this.base(deckId)}/${cardId}`);
  }

  create(deckId: number, card: CardCreate): Observable<Card> {
    return this.http.post<Card>(this.base(deckId), card);
  }

  update(deckId: number, cardId: number, card: CardCreate): Observable<Card> {
    return this.http.put<Card>(`${this.base(deckId)}/${cardId}`, card);
  }

  delete(deckId: number, cardId: number): Observable<void> {
    return this.http.delete<void>(`${this.base(deckId)}/${cardId}`);
  }
}
