import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/user.service';

@Component({
  selector: 'app-setting',
  templateUrl: './setting.component.html',
  styleUrls: ['./setting.component.scss']
})
export class SettingComponent implements OnInit {
  postError: boolean;
  success: boolean;
  postErrorMessage = '';

  constructor(private userService: UserService) { }
  changePasswordModel = {
    UserId: localStorage.getItem('userId'),
    UserName: '',
    OldPassword: '',
    NewPassword: '',
  };
  ngOnInit() {
  }

  changePassword() {
    this.userService.changePassword(this.changePasswordModel).subscribe(
      (data: any) => {
        if (data.succeeded === false) {
          this.success = false;
          data.errors.forEach(element => {
            this.onHttpError(element.description);
          });
        } else {
          this.postError = false;
          this.success = true;
        }
        console.log(data);
      },
      err => {
        console.log(err);
      }
    );
  }
  onHttpError(error: any) {
    console.log('error', error);
    this.postError = true;
    this.postErrorMessage = error;
  }

}
