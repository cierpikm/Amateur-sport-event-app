import { UserProfile } from './userProfile';
import { Chat } from './chat';

export interface Message {
    messageText: string;
    dateSendMessage: Date;
    senderId: string;
    reciverId: string;
    sender: UserProfile;
    reciver: UserProfile;
    chatId: number;

}
