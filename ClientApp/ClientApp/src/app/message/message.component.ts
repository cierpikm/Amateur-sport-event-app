import { MessageService } from './../shared/message.service';
import { Component, OnInit } from '@angular/core';
import { Chat } from '../models/Chats/chat';
import { HubConnectionBuilder, HubConnection } from '@aspnet/signalr';
@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.scss']
})
export class MessageComponent implements OnInit {
  chat: Chat;
  showChat = false;
  owner = false;
  chats: Chat[];
  connection: HubConnection;
  newMessage;
  amauntMessage = 0;

  constructor(private messageService: MessageService) {}

  ngOnInit() {
    this.messageService
    .getChats()
    .subscribe(
      chats => {
       this.chats = chats;
       console.log(chats);
      },
      error => {
        console.log(error);
      }
    );
    this.connection = new HubConnectionBuilder()
    .withUrl('https://localhost:44352/chatHub', {
      accessTokenFactory: () => localStorage.getItem('token')
    })
    .build();

    this.connection.on('SendMessage', data => {
    console.log(data);
  });

    this.connection
    .start()
    .then(() => console.log('Connection started!'))
    .catch(err => console.log('Error while establishing connection :('));

    this.connection.on(
    'send',
    (message) => {
      console.log(message);
      this.chats.forEach(element => {
        if (element.id === message.chatId) {
          element.messages.push(message);
        }
      });
      this.newMessage = message.chatId;
      this.amauntMessage++;
    }
  );
  }
  getChat(chatId) {

    this.messageService.getChat(chatId).subscribe(
    (data) => {
        this.chat = data;
        this.amauntMessage = 0;
        this.newMessage = false;
        console.log(data);
      },
      err => {
        console.log(err);
      }
    );
    this.showChat = true;
  }
  checkOwner(ownerId) {
      if (ownerId === localStorage.getItem('userId')) {
        this.owner = true;
   }
      return true;
 }
 public createImgPath = (serverPath: string) => {
  return `https://localhost:44352/${serverPath}`;
}
}
