import { Sports } from './sports';
import { LevelUser } from './levelUser';
import { Localization } from './localization';
export interface Advertisement {
  Title: string;
  SportType: Sports;
  Date: Date;
  Localization: Localization;
  LevelUser: LevelUser;
  AgeRange: number;
  ExtraInformation: string;
  UserId: string;
}
