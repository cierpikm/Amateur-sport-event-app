import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {
  onGallery = false;
  onAchievement = false;
  onInfo = false;
  onOwnAdvertisement = false;
  userName;
  user;
  constructor(private route: ActivatedRoute, private userService: UserService) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.userName = params.get('userName');
    });
    this.userService.getUser(this.userName).subscribe(
      data => {
        this.user = data;
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );
  }
  clickGallery() {
    this.onGallery = true;
    this.onAchievement = false;
    this.onInfo =  false;
    this.onOwnAdvertisement = false;

  }
  clickAchievement() {
    this.onAchievement = true;
    this.onGallery = false;
    this.onInfo = false;
    this.onOwnAdvertisement = false;

  }
  clickInfo() {
    this.onAchievement = false;
    this.onGallery = false;
    this.onInfo = true;
    this.onOwnAdvertisement = false;

  }
  clickOwnAdvertisement() {
    this.onAchievement = false;
    this.onGallery = false;
    this.onInfo = false;
    this.onOwnAdvertisement = true;
  }
}
