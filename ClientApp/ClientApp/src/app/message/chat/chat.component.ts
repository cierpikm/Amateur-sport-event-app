import {
  Component,
  OnInit,
  Input,
  NgZone,
  ViewChild,
  ViewChildren,
  QueryList
} from '@angular/core';
import { MessageService } from 'src/app/shared/message.service';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { take } from 'rxjs/operators';
import { CdkVirtualScrollViewport } from '@angular/cdk/scrolling';
import { Chat } from 'src/app/models/Chats/chat';
import { Message } from 'src/app/models/Chats/message';
@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {
  constructor(
    private messageService: MessageService,
    private _ngZone: NgZone
  ) {}
  @Input() chat: Chat;
  @ViewChildren('messages')
  messages: QueryList<HTMLElement>;
  messageText;
  userId = localStorage.getItem('userId');
  connection: HubConnection;

  @ViewChild(CdkVirtualScrollViewport, { static: false })
  public virtualScrollViewport?: CdkVirtualScrollViewport;
  @ViewChild('autosize', { static: false }) autosize: CdkTextareaAutosize;

  ngAfterViewInit() {
    this.messages.changes.subscribe(() => {
      const length = this.chat.messages.length;
      this.virtualScrollViewport.scrollToIndex(length * 9, 'smooth');
    });
  }

  ngOnInit() {
    console.log(this.chat);

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
        this.chat.messages.push(message);
        console.log(message);
      }
    );
  }

  sendMessage() {
    let reciverId;
    const actualDate = new Date();
    if (this.chat.reciver.id === this.userId) {
      reciverId = this.chat.owner.id;
    } else {
      reciverId = this.chat.reciver.id;
    }

    const message: Message = {
      messageText: this.messageText,
      dateSendMessage: actualDate,
      chatId: this.chat.id,
      senderId: this.userId,
      reciverId,
    };
    const message2: Message = {
      messageText: this.messageText,
      dateSendMessage: actualDate,
      chatId: this.chat.id,
      senderId: this.userId,
      reciverId,
      sender: {imageURL: localStorage.getItem('imageURL')}
    };
    this.chat.messages.push(message2);
    this.messageService.sendMessage(message).subscribe(
      data => {
        console.log(data);
      },
      err => {
        console.log(err);
      }
    );
  }
  triggerResize() {
    this._ngZone.onStable
      .pipe(take(1))
      .subscribe(() => this.autosize.resizeToFitContent(true));
  }
  public createImgPath = (serverPath: string) => {
    return `https://localhost:44352/${serverPath}`;
  }
}
