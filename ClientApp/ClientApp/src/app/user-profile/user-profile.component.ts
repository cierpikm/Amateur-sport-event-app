import { UserProfile } from './../data/userProfile';
import { UserService } from './../shared/user.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Sports } from '../data/sports';
import { Router } from '@angular/router';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  sports: Sports;
  selectedSport;

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
        this.userService.userProfile = data;
        this.userProfile = data;
        localStorage.setItem('city', this.userProfile.city);
        console.log(this.userService.userProfile);
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );
    this.openSnackBar('Nie zapomnij uzupełnic swpjego profilu!', 'Uzupełnij');

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
    this.userService.updateProfile(this.userService.userProfile).subscribe(
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
      Vaule: this.selectedSport,
      UserId: localStorage.getItem('userId')
    };
    this.userService.addPrefferSport(body).subscribe(
      data => {
        console.log(data);
        this.ngOnInit();
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
}
