import { Injectable } from '@angular/core';
import { CreatePageViewModel } from '../models/createPageViewModel.model';
import { Page } from '../models/page.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class PageService extends BaseService {

  async getPage(id: number): Promise<Page> {
    return await super.httpGet<Page>(`page/getPage/${id}`);
  }

  createPage(model: CreatePageViewModel): void {
    super.httpPost<CreatePageViewModel>('page/createPage', model);
  }

  editBook(page: Page): void {
    super.httpPost<Page>('page/editBook', page);
  }

  deleteBook(id: number): void {
    super.httpDelete(`page/deleteBook/${id}`);
  }
}
