import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Chat } from '../models/Chats/chat';
import { map } from 'rxjs/operators';
@Injectable()
export class MessageService {
  constructor(private http: HttpClient) {}
  readonly url = 'https://localhost:44352/api/Message';
  getChats(): Observable<Chat[]> {
    return this.http.get(this.url + '/GetChats/' + localStorage.getItem('userId')).pipe(
      map((res: Chat[]) => {
        return res;
      })
    );
  }
  getChat(chatId): Observable<Chat> {
    return this.http.get(this.url + '/GetChat/' + chatId).pipe(
      map((res: Chat) => {
        return res;
      })
    );
  }
  sendMessage(message) {
    return this.http.post(this.url + '/SendMessage', message);
  }
  openChat(chatUsers) {
    return this.http.post(this.url + '/OpenChat', chatUsers);
  }
}
