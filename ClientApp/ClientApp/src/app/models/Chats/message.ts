import { UserProfile } from './userProfile';

export interface Message {
    messageText?: string;
    dateSendMessage?: Date;
    senderId?: string;
    reciverId?: string;
    sender?: UserProfile;
    reciver?: UserProfile;
    chatId?: number;

}
