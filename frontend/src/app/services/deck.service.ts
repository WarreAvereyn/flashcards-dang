import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Deck, DeckCreate } from '../models/deck.model';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class DeckService {
  private base = `${environment.apiUrl}/decks`;

  constructor(private http: HttpClient) {}

  getAll(): Observable<Deck[]> {
    return this.http.get<Deck[]>(this.base);
  }

  getById(id: number): Observable<Deck> {
    return this.http.get<Deck>(`${this.base}/${id}`);
  }

  create(deck: DeckCreate): Observable<Deck> {
    return this.http.post<Deck>(this.base, deck);
  }

  update(id: number, deck: DeckCreate): Observable<Deck> {
    return this.http.put<Deck>(`${this.base}/${id}`, deck);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.base}/${id}`);
  }
}
