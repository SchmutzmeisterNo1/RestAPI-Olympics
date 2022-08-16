export enum RoleTypeEnum {
  User = 1,
  Supporter = 2,
  Moderator = 3,
  Administrator = 4
}

export class Role {
  Id: number;
  Name: string;
  RoleType: RoleTypeEnum;
}
