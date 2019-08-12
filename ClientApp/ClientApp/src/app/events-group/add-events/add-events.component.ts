import { EventService } from './../../shared/event.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-events',
  templateUrl: './add-events.component.html',
  styleUrls: ['./add-events.component.scss']
})
export class AddEventsComponent implements OnInit {
  min = new Date();
  event = {
    Title: '',
    SportType: 0,
    Date: new Date(),
    Localization: {
      Street: '', StreetNumber: 0,  City: ''},
    ExtraInformation: '',
    description: '',
    facebookURL: '',
    twitterURL: '',
    instagramURL: '',
    officialPageURL: '',
    sponsors: [{
      name: '',
      type: ''
    }],
    organizer: '',
    shortDescription: '',
    UserId: localStorage.getItem('userId')
  };
  sponsor = {
    name: '',
    type: ''
  };
  constructor(private router: Router, private eventService: EventService) { }

  ngOnInit() {
  }
  navigate() {
    this.router.navigateByUrl('user/event');
  }
  saveAdvertisement() {
    this.eventService.addEvent(this.event).subscribe(
      data => {
        console.log(data);
      },
      error => {
        console.log(error);
      }
    );

  }
}
