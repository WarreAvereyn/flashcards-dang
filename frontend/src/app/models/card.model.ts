export interface Card {
  id: number;
  deckId: number;
  front: string;
  back: string;
  createdAt: string;
  updatedAt: string;
}

export interface CardCreate {
  front: string;
  back: string;
}
