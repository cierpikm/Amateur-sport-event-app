import { MessageService } from "./../shared/message.service";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { UserService } from "../shared/user.service";

@Component({
  selector: "app-users",
  templateUrl: "./users.component.html",
  styleUrls: ["./users.component.scss"]
})
export class UsersComponent implements OnInit {
  onGallery = false;
  onAchievement = false;
  onInfo = false;
  onOwnAdvertisement = false;
  userName;
  user;
  constructor(
    private route: ActivatedRoute,
    private userService: UserService,
    private messageService: MessageService,
    private router: Router
  ) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.userName = params.get("userName");
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
    this.onInfo = false;
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
  sendMessage() {
    const chatUsers = {
      ReciverId: this.user.id,
      SenderId: localStorage.getItem("userId")
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
  public createImgPath = (serverPath: string) => {
    return `https://localhost:44352/${serverPath}`;
  }
}
