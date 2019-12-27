import { UserService } from './../shared/user.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {MatSnackBar} from '@angular/material/snack-bar';
import { Sports } from '../models/sports';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  sports: Sports;
  selectedSport;
  public response: {dbPath: ''};
  updateOff = true;
  constructor(
    private userService: UserService,
    private router: Router,
    private _snackBar: MatSnackBar
  ) {}
  userProfile;
  ngOnInit() {
    this.userService.getUserProfile().subscribe(
      data => {
        this.userProfile = data;
        localStorage.setItem('city', this.userProfile.city);
        localStorage.setItem('userId', this.userProfile.id);
        localStorage.setItem('firstName', this.userProfile.firstName);
        localStorage.setItem('lastName', this.userProfile.lastName);
        localStorage.setItem('userName', this.userProfile.userName);
        localStorage.setItem('imageURL', this.userProfile.imageURL);


        if (this.userProfile.imageURL === null) {
          this.userProfile.imageURL = `Resources/Images/default.png`;
          this.saveUpdate();
        }
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );
    this.openSnackBar('Nie zapomnij uzupełnic swojego profilu!', 'Uzupełnij');



  }
  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000,
    });
  }
  update() {
    this.updateOff = false;
  }
  saveUpdate() {

    this.userService.updateProfile(this.userProfile).subscribe(
      data => {
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );
    this.updateOff = true;
  }

  Logout() {
    localStorage.removeItem('token');
  }
  toSportsEnum(sports) {
    return Sports[sports];
  }
  addPrefferSport() {
    const body = {
      vaule: this.selectedSport,
      userId: localStorage.getItem('userId')
    };
    this.userService.addPrefferSport(body).subscribe(
      data => {
        console.log(data);
        this.userProfile.prefferedSports.push(data);
      },
      error => {
        console.log(error);
      }
    );
  }
  delete(id) {
    this.userService.deletePrefferSport(id).subscribe(
      data => {
        console.log(data);
        this.ngOnInit();
      },
      error => {
        console.log(error);
      }
    );
  }
  onNavigateToUserProfile(userName) {
    this.router.navigateByUrl('user/users/' + userName);
  }

public uploadFinished = (event) => {
    this.response = event;
    this.userProfile.imageURL = this.response.dbPath;

  }
  public createImgPath = (serverPath: string) => {
    return `https://localhost:44352/${serverPath}`;
  }
}
