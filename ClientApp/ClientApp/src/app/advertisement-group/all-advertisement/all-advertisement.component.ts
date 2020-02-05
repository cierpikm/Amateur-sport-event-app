import { Component, OnInit } from '@angular/core';
import { AdvertisementService } from 'src/app/shared/advertisement.service';
import { map } from 'rxjs/operators';
@Component({
  selector: 'app-all-advertisement',
  templateUrl: './all-advertisement.component.html',
  styleUrls: ['./all-advertisement.component.scss']
})
export class AllAdvertisementComponent implements OnInit {
  showedItem = 0;
  advertisements = [];
  constructor(private advertisementService: AdvertisementService) { }

  ngOnInit() {
    this.getAllAdvertisement('', localStorage.getItem('userId'));
  }
  getAllAdvertisement(city, userId) {
    this.advertisementService
      .getAllAdvertisement(city, userId)
      .pipe(
        map((advertisements: []) => {
          return advertisements;
        })
      )
      .subscribe(
        advertisements => {
          for (const i of advertisements) {
            this.advertisements.push(i);
          }
        }
      );
    if (this.advertisements.length === 0) {
      this.advertisementService.openSnackBar('Brak innych ogłoszeń', 'Brak');
    }
  }
  nextAdvertisement(value) {
    this.showedItem = value;
  }
  filtering() {
    this.advertisements = [];
    this.getAllAdvertisement(localStorage.getItem('city'), localStorage.getItem('userId'));
  }
}
