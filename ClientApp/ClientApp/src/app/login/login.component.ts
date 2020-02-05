import { Component, OnInit, Inject } from '@angular/core';
import { UserService } from '../shared/user.service';
import { FormGroup, FormControl } from '@angular/forms';
import { UserLogin } from '../models/userLogin';
import { Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  constructor(
    private userService: UserService,
    private router: Router,
    public dialogRef: MatDialogRef<LoginComponent>
  ) { }
  userLogin: UserLogin = {
    Username: '',
    Password: ''
  };
  loginError = false;
  postErrorMessag = '';

  ngOnInit() { }
  onSubmit() {
    this.loginError = false;
    this.userService.login(this.userLogin).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        this.getUser();
        this.router.navigateByUrl('/user/profile');
        this.dialogRef.close();
      },
      error => {
        if (error.status === 400) {
          this.loginError = true;
          this.postErrorMessag = error.error.message;
        }
      }
    );
  }
  getUser() {
    this.userService.getUserProfile().subscribe(
      (data: any) => {
        localStorage.setItem('userId', data.id);
      }
    );
  }
}
