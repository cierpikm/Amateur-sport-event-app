import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/user.service';
import { UserAuth } from '../data/userAuth';
import { Router } from '@angular/router';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  userAuth: UserAuth = {
    UserName: '',
    Email: '',
    Password: ''
  };
  postErrorMessage = '';
  postError: boolean;
  constructor(
    private userService: UserService,
    private router: Router,
    public dialogRef: MatDialogRef<RegisterComponent>
  ) {}

  ngOnInit() {}
  signIn() {
    this.userService.postUser(this.userAuth).subscribe(
      (res: any) => {
        if (res.succeeded === false) {
          res.errors.forEach(element => {
            this.onHttpError(element.description);
          });
        } else {
          console.log('POST Request is successful ', res);
          this.postError = false;
          this.dialogRef.close();
          this.userService.login(this.userAuth).subscribe((data: any) => {
            console.log('POST Request is successful', data);
            localStorage.setItem('token', data.token);
            this.router.navigateByUrl('/user/profile');
          });
        }
      },
      error => {
        this.onHttpError(error.message);
      }
    );
  }
  onHttpError(error: any) {
    console.log('error', error);
    this.postError = true;
    this.postErrorMessage = error;
  }
}
