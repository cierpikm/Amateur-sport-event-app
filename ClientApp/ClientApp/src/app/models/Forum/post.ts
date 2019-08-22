import { UserProfile } from '../Chats/userProfile';
import { Forum } from './forum';

export interface Post {
    id?: number;
    postText?: string;
    dateSendMessage?: Date;
    ownerId?: string;
    owner?: UserProfile;
    forumId?: number;
    forum?: Forum;
    reciver?;
}
