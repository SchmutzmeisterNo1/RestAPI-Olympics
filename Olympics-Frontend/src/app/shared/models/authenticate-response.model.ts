import { User } from "./user.model";

export interface AuthenticateResponse {
  Token: string;
  User: User;
}
