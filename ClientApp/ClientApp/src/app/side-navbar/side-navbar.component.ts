import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HubConnectionBuilder, HubConnection } from '@aspnet/signalr';


@Component({
  selector: 'app-side-navbar',
  templateUrl: './side-navbar.component.html',
  styleUrls: ['./side-navbar.component.scss']
})
export class SideNavbarComponent implements OnInit {
  constructor(private router: Router) {}
  connection: HubConnection;
  newMessage = false;
  ngOnInit() { this.connection = new HubConnectionBuilder()
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

      this.newMessage = true;
    }
  ); }
  Logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
    localStorage.removeItem('city');
    this.router.navigateByUrl('/');
  }
  resetBadge() {
    this.newMessage = false;
  }
}
