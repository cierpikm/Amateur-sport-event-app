import { Achievement } from './achievement';
import { Sports } from './sports';

export interface UserProfile {
   FirstName: string;
   LastName: string;
   Description: string;
   Age: number;
   ImageURL: string;
   PrefferedSports: Sports;
   AchievementID: number;
}
