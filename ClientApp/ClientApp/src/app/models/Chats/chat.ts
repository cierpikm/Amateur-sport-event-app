import { QueryList } from '@angular/core';
import { Message } from './message';
import { UserProfile } from './userProfile';

export interface Chat {
  id?: number;
  messages?: Message[];
  ownerId?: string;
  reciverId?: string;
  owner?: UserProfile;
  reciver?: UserProfile;
}
