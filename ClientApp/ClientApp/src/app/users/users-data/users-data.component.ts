import { Component, OnInit, Input } from '@angular/core';
import { Sports } from 'src/app/models/sports';


@Component({
  selector: 'app-users-data',
  templateUrl: './users-data.component.html',
  styleUrls: ['./users-data.component.scss']
})
export class UsersDataComponent implements OnInit {
  @Input() user;
  constructor() { }

  ngOnInit() {

  }
  toSportsEnum(sports) {
    return Sports[sports];
  }
}
