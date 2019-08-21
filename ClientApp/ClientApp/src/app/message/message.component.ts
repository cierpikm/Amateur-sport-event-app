import { MessageService } from './../shared/message.service';
import { Component, OnInit } from '@angular/core';
import { Chat } from '../models/Chats/chat';
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
  }
  getChat(chatId) {
    this.messageService.getChat(chatId).subscribe(
    (data) => {
        this.chat = data;
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
}
