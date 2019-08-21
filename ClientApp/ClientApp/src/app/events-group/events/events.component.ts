import { AcceptedAdvertisementComponent } from './../../advertisement-group/accepted-advertisement/accepted-advertisement.component';
import { Router } from '@angular/router';
import { EventService } from '../../shared/event.service';
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { Sports } from '../../models/sports';
import { map } from 'rxjs/operators';


@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {
  events = [];

  constructor( private eventService: EventService, private router: Router) {}
  isClicked = [];
  clickedItem = 1;
  number = [1, 2, 3];

  ngOnInit() {
    this.getAllEvents(1);
  }
  toSportsEnum(sports) {
    return Sports[sports];
  }
  addEvent() {
    this.router.navigateByUrl('user/addEvent');
  }
  nextPage() {
    for (let i = 0; i < this.number.length; i++) {
      this.number[i] ++;
    }
    this.clickedItem ++;
    this.events = [];
    this.getAllEvents(this.clickedItem);

  }
  previousPage() {
    for (let i = 0; i < this.number.length; i++) {
      this.number[i] --;
    }
    this.clickedItem --;
    this.events = [];
    this.getAllEvents(this.clickedItem);
  }
  getAllEvents(pageNumber) {
    this.events = [];
    this.eventService
    .getAllEvents(pageNumber)
    .pipe(
      map((events: []) => {
        return events;
      })
    )
    .subscribe(
      events => {
        for (const i of events) {
          this.events.push(i);
        }
        console.log(events);
      },
      error => {
        console.log(error);
      }
    );
  }

}

