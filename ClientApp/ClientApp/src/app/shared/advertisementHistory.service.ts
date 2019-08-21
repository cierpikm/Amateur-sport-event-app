import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class AdvertisementHistoryService {
  url = 'https://localhost:44352/api';
  constructor(
    private http: HttpClient,
  ) {}
  getAllOneAdvertisement() {
    return this.http.get(
      this.url +
        '/AdvertisementArch/GetAllOneAdvertisements/' +
        localStorage.getItem('userId')
    );
  }
  getAllAcceptedAdvertisements() {
    return this.http.get(
      this.url +
        '/AdvertisementArch/GetAllAcceptedAdvertisements/' +
        localStorage.getItem('userId')
    );
  }
}
