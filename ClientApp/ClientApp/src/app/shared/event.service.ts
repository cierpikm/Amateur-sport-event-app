import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class EventService {
  readonly url = 'https://localhost:44378/api/Event';
  constructor(private http: HttpClient) {}
  getAllEvents(pageNumber) {
    return this.http.get(this.url + '/GetAllEvents?pageNumber=' + pageNumber);
  }
  addEvent(event) {
    return this.http.post(this.url + '/AddEvent' , event);
  }
  addSponsor(sponsor) {
    return this.http.post('https://localhost:44378/api/Sponsor/AddSponsor', sponsor);
  }
}
