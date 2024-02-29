export class Book {
  bookId?: number;
  title?: string;
  author?: string;
  publisher?: string;
  rating?: number;
  spiceLevel?: number;
  description?: string;
  addedAt?: Date;
  coverUrl?: string;
}

export class ResponseDto<T> {
  responseData?: T;
  messageToClient?: string;
}
