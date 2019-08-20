import { Component, OnInit, Input, NgZone, ViewChild } from '@angular/core';
import { MessageService } from 'src/app/shared/message.service';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import {CdkTextareaAutosize} from '@angular/cdk/text-field';
import {take} from 'rxjs/operators';
import { CdkVirtualScrollViewport } from '@angular/cdk/scrolling';
@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {
  constructor(private messageService: MessageService,
              private _ngZone: NgZone) { }
  @Input() chat;
  messageText;
  userId = localStorage.getItem('userId');
  connection: HubConnection;

  @ViewChild(CdkVirtualScrollViewport, {static: false})
  public virtualScrollViewport?: CdkVirtualScrollViewport;
  @ViewChild('autosize', {static: false}) autosize: CdkTextareaAutosize;



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

    this.connection.on('send', (MessageText, SenderId, ReciverId, ChatId, dateSendMessage) => {
      if (ReciverId === this.userId) {
        ReciverId = this.chat.owner.id;
      } else {
        ReciverId = this.chat.reciver.id;
      }
      const message = {
        messageText: MessageText,
        sender: {id: this.userId},
        reciver: {id: ReciverId},
        chatId: ChatId,
        DateSendMessage: dateSendMessage
      };
      this.chat.messages.push(message);
      console.log(MessageText, SenderId, ReciverId, ChatId);
  });
  }

   sendMessage() {
    let reciverId;
    const actualDate =  new Date();
    if (this.chat.reciver.id === this.userId) {
       reciverId = this.chat.owner.id;
    } else {
      reciverId =  this.chat.reciver.id;
    }

    const message = {
      messageText: this.messageText,
      dateSendMessage: actualDate,
      sender: {id: this.userId},
      reciver: {id: reciverId},
      chatId: this.chat.id
    };
    this.chat.messages.push(message);
    const length = this.chat.messages.length;
    const message2 = {
      messageText: this.messageText,
      dateSendMessage: actualDate,
      senderId: this.userId,
      reciverId,
      chatId: this.chat.id,
    };
    this.messageService.sendMessage(message2).subscribe(
      data => {
        console.log(data);

        this.virtualScrollViewport.scrollToIndex(length, 'smooth');

      },
      err => {
        console.log(err);
      }
    );
  }

  triggerResize() {
    // Wait for changes to be applied, then trigger textarea resize.
    this._ngZone.onStable.pipe(take(1))
        .subscribe(() => this.autosize.resizeToFitContent(true));
  }
}
