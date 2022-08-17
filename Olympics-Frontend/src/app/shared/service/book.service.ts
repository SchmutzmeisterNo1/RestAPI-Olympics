import { Injectable } from '@angular/core';
import { Book } from '../models/book.model';
import { CreateBookViewModel } from '../models/createBookViewModel.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class BookService extends BaseService {

  async getBook(id: number): Promise<Book> {
    return await super.httpGet<Book>(`book/getBook/${id}`);
  }

  createBook(model: CreateBookViewModel): void {
    super.httpPost<CreateBookViewModel>('book/createBook', model);
  }

  editBook(book: Book): void {
    super.httpPost<Book>('book/editBook', book);
  }

  deleteBook(id: number): void {
    super.httpDelete(`book/deleteBook/${id}`);
  }
}
