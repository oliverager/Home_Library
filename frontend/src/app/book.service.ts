import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {State} from "../state";
import {firstValueFrom} from "rxjs";
import {Book, ResponseDto} from "../models";
import {environment} from "../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(public Http: HttpClient, public state: State) { }

  async fetchBookFeed() {
    const result = await firstValueFrom(this.Http.get<ResponseDto<Book[]>>(environment.baseUrl + '/api/books'))
    this.state.books = result.responseData!;
    }

  GetBookById(bookId: number): Book | undefined {
    return this.state.books.find(book => book.bookId === bookId)
  }
}
