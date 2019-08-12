import { Component, OnInit, Inject } from '@angular/core';
import { UserService } from '../shared/user.service';
import { FormGroup, FormControl } from '@angular/forms';
import { UserLogin } from '../data/userLogin';
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
  ) {}
  userLogin: UserLogin = {
    Username: '',
    Password: ''
  };
  loginError = false;
  postErrorMessag = '';

  ngOnInit() {}

  onSubmit() {
    this.userService.getUserProfile().subscribe(
      (data: any) => {
        localStorage.setItem('userId', data.id);
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );

    this.userService.login(this.userLogin).subscribe(
      (res: any) => {
        console.log('POST Request is successful', res);
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/user/profile');
        this.dialogRef.close();

      },
      error => {
        if (error.status === 400) {
          console.log(error);
          this.loginError = true;
          this.postErrorMessag = error.message;
        }
      }
    );
  }
}
