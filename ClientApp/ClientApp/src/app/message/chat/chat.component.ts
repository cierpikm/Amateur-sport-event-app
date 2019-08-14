import { Component, OnInit, Input } from '@angular/core';
import { MessageService } from 'src/app/shared/message.service';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {
  @Input() chat;
  messageText;
  userId = localStorage.getItem('userId');
  connection: HubConnection;
  constructor(private messageService: MessageService) { }

  ngOnInit() {
    this.connection = new HubConnectionBuilder()
    .withUrl('https://localhost:44352/chatHub', {accessTokenFactory: () => localStorage.getItem('token')})
    .build();

    this.connection.on('SendMessage', data => {
    console.log(data);
  });

    this.connection
    .start()
    .then(() => console.log('Connection started!'))
    .catch(err => console.log('Error while establishing connection :('));

    this.connection.on('send', (MessageText, SenderId, ReciverId, ChatId) => {
      if (ReciverId === this.userId) {
        ReciverId = this.chat.owner.id;
      } else {
        ReciverId = this.chat.reciver.id;
      }
      const message = {
        messageText: MessageText,
        sender: {id: this.userId},
        reciver: {id: ReciverId},
        chatId: ChatId
      };
      this.chat.messages.push(message);
      console.log(MessageText, SenderId, ReciverId, ChatId);
  });
  }

   sendMessage() {
    let reciverId;
    if (this.chat.reciver.id === this.userId) {
       reciverId = this.chat.owner.id;
    } else {
      reciverId =  this.chat.reciver.id;
    }

    const message = {
      messageText: this.messageText,
      sender: {id: this.userId},
      reciver: {id: reciverId},
      chatId: this.chat.id
    };
    this.chat.messages.push(message);
    const message2 = {
      messageText: this.messageText,
      senderId: this.userId,
      reciverId :reciverId,
      chatId: this.chat.id
    };
    this.messageService.sendMessage(message2).subscribe(
      data => {
        console.log(data);
      },
      err => {
        console.log(err);
      }
    );
  }
}
