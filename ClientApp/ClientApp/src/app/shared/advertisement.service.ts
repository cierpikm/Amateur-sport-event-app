import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserService } from './user.service';
import { Advertisement } from '../models/advertisement';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable()
export class AdvertisementService {
  url = 'https://localhost:44352/api';
  constructor(
    private http: HttpClient,
    private _snackBar: MatSnackBar
  ) {}
  getAllAdvertisement(city, userId) {
    return this.http.get(
      this.url +
        '/Advertisement/GetAllAdvertisement/' +
        userId +
        '?city=' +
        city
    );
  }
  addMemberToAdvertisement(advertisementId) {
    return this.http.post(
      this.url +
        '/Advertisement/AddMemberToAdvertisement/' +
        localStorage.getItem('userId') +
        '/' +
        advertisementId,
      null
    );
  }
  getAllOneAdvertisement() {
    return this.http.get(
      this.url +
        '/Advertisement/GetAllOneAdvertisements/' +
        localStorage.getItem('userId')
    );
  }
  getAllAcceptedAdvertisements() {
    return this.http.get(
      this.url +
        '/Advertisement/GetAllAcceptedAdvertisements/' +
        localStorage.getItem('userId')
    );
  }
  addAdvertisement(body) {
    return this.http.post(this.url + '/Advertisement/AddAdvertisement', body);
  }
  openSnackBar(message: string, action: string) {
    this._snackBar.open(message, action, {
      duration: 2000
    });
  }
}
