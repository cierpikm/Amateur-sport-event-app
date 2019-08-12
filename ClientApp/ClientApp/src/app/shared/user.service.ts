import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class UserService {
  userProfile;
  readonly urlPostUser = 'https://localhost:44378/api';
  readonly tokenHeader = new HttpHeaders({ Authorization: 'Bearer ' + localStorage.getItem('token') });
  constructor(private httpClient: HttpClient) { }

  postUser(body: any) {
    return this.httpClient.post(this.urlPostUser + '/User/PostUser', body);
  }
  login(body: any) {
    return this.httpClient.post(this.urlPostUser + '/User/Login', body);
  }
  getUserProfile() {
    return this.httpClient.get(this.urlPostUser + '/User/GetUserProfile', {headers: this.tokenHeader});
  }
  getUser(userName) {
    return this.httpClient.get(this.urlPostUser + '/User/GetUser/' + userName , {headers: this.tokenHeader});
  }
  updateProfile(user) {
    return this.httpClient.post(this.urlPostUser + '/User/UpdateUser', user, {headers: this.tokenHeader});
  }
  addPrefferSport(body) {
    return this.httpClient.post(this.urlPostUser + '/PrefferedSports/AddPrefferedSport', body);
  }
  deletePrefferSport(id) {
    return this.httpClient.delete(this.urlPostUser + '/PrefferedSports/Delete/' + id);
  }
}
