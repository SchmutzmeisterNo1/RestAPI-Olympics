import { Book } from "./book.model";
import { User } from "./user.model";

export class Page {
  Id: number;
  Value: string;
  BookId: number;
  Book: Book;
  CreationUserId: number;
  CreationUser: User;
  CreationDate: Date;
  LastUpdatedUserId: number;
  LastUpdatedUser: User;
  LastUpdatedDate: Date;
}