import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
@Injectable()
export class MessageService {
  constructor(private http: HttpClient) {}
  readonly url = 'https://localhost:44352/api/Message';
  getChats() {
    return this.http.get(this.url + '/GetChats/' + localStorage.getItem('userId'));
  }
  getChat(chatId) {
    return this.http.get(this.url + '/GetChat/' + chatId);
  }
  sendMessage(message) {
    return this.http.post(this.url + '/SendMessage', message);
  }
}
