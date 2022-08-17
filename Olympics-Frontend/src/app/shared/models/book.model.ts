import { Page } from "./page.model";
import { Shelve } from "./shelve.model";
import { User } from "./user.model";

export class Book {
  Id: number;
  Headline: string;
  ShelveId: number;
  Shelve: Shelve;
  CreationUserId: number;
  CreationUser: User;
  CreationDate: Date;
  LastUpdatedUserId: number;
  LastUpdatedUser: User;
  LastUpdatedDate: Date;
  Pages: Page[];
}
