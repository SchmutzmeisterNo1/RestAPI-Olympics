import { Book } from "./book.model";
import { User } from "./user.model";

export class Shelve {
  Id: number;
  Headline: string;
  Description: string;
  CreationUserId: number;
  CreationUser: User;
  CreationDate: Date;
  LastUpdatedUserId: number;
  LastUpdatedUser: User;
  LastUpdatedDate: Date;
  Books: Book[];
}
