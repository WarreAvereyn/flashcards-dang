export interface Deck {
  id: number;
  name: string;
  description: string;
  createdAt: string;
  updatedAt: string;
}

export interface DeckCreate {
  name: string;
  description: string;
}
