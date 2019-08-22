import { Post } from './post';
import { UserProfile } from '../Chats/userProfile';

export interface Forum {
  id: number;
  advrtismntId: number;
  posts: Post[];
  users: UserProfile[];
}
