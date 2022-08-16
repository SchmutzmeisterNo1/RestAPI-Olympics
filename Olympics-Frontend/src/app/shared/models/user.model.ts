import { Role } from "./role.model";

export class User {
  Id: number;
  Firstname: string;
  Lastname: string;
  Email: string;
  Password: string;
  RoleId: number;
  Role?: Role;
}
