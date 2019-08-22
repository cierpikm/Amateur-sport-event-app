import { Router } from '@angular/router';
import { ForumService } from './../shared/forum.service';
import {
  Component,
  OnInit,
  Input,
  ViewChild,
  QueryList,
  ViewChildren
} from '@angular/core';
import { Forum } from '../models/Forum/forum';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { CdkVirtualScrollViewport } from '@angular/cdk/scrolling';
import { Post } from '../models/Forum/post';
import { MessageService } from '../shared/message.service';
import { CdkTextareaAutosize } from '@angular/cdk/text-field';

@Component({
  selector: 'app-forum',
  templateUrl: './forum.component.html',
  styleUrls: ['./forum.component.scss']
})
export class ForumComponent implements OnInit {
  constructor(
    private forumService: ForumService,
    private router: Router,
    private messageService: MessageService
  ) {}
  @Input() advertisementId: number;
  PostText;
  forum: Forum;
  connection: HubConnection;

  ngOnInit() {
    this.forumService.getForum(this.advertisementId).subscribe(
      data => {
        this.forum = data;
        console.log(data);
      },
      err => {
        console.log(err);
      }
    );
    this.connection = new HubConnectionBuilder()
      .withUrl('https://localhost:44352/chatHub', {
        accessTokenFactory: () => localStorage.getItem('token')
      })
      .build();

    this.connection.on('SendPostToForum', data => {
      console.log(data);
    });

    this.connection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));

    this.connection.on('SendPost', post => {
      this.forum.posts.push(post);
      console.log(post);
    });
  }
  addPost() {
    const actualDate = new Date();
    const reciver = [];

    this.forum.users.forEach(element => {
      if (element.id !== localStorage.getItem('userId')) {
        reciver.push(element.id);
      }

    });
    const post: Post = {
      postText: this.PostText,
      dateSendMessage: actualDate,
      ownerId: localStorage.getItem('userId'),
      owner: {
        firstName: localStorage.getItem('firstName'),
        lastName: localStorage.getItem('lastName'),
        userName: localStorage.getItem('userName'),
      },
      forumId: this.forum.id,
      reciver
    };
    this.forum.posts.push(post);
    this.forumService.addPost(post).subscribe(
      data => {
        console.log(data);
      },
      err => {
        console.log(err);
      }
    );
  }
  onNavigateToUserProfile(userName) {
    this.router.navigateByUrl('user/users/' + userName);
  }
  sendMessage(userId) {
    const chatUsers = {
      ReciverId: userId,
      SenderId: localStorage.getItem('userId')
    };
    this.messageService.openChat(chatUsers).subscribe(
      data => {
        console.log(data);
        this.router.navigateByUrl('user/message');
      },
      err => {
        console.log(err);
      }
    );
  }
}
