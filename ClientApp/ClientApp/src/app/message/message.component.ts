import { MessageService } from './../shared/message.service';
import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { map } from 'rxjs/operators';
@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.scss']
})
export class MessageComponent implements OnInit {
  chat;
  showChat = false;

  chats = [];

  constructor(private messageService: MessageService) {}

  ngOnInit() {
    this.messageService
    .getChats()
    .pipe(
      map((chats: []) => {
        return chats;
      })
    )
    .subscribe(
      chats => {
        for (const i of chats) {
          this.chats.push(i);
        }
        console.log(chats);
      },
      error => {
        console.log(error);
      }
    );


  }
  getChat(chatId) {
    this.messageService.getChat(chatId).subscribe(
      data => {
        this.chat = data;
        console.log(data);
      },
      err => {
        console.log(err);
      }
    );
    this.showChat = true;
  }
}
