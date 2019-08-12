import { Component, OnInit } from '@angular/core';

import { FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from '../login/login.component';
import { RegisterComponent } from '../register/register.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  constructor(public dialog: MatDialog) {}

  ngOnInit() {}
  openLogin(): void {
     this.dialog.open(LoginComponent, {
      width: '450px',
      height: '500px'
    });
  }
  openRegister(): void {
    this.dialog.open(RegisterComponent, {
     width: '450px',
     height: '500px'
   });
 }
}
