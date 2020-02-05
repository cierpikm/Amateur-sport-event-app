import { Localization } from '../../models/localization';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Advertisement } from 'src/app/models/advertisement';
import { AdvertisementService } from 'src/app/shared/advertisement.service';

@Component({
  selector: 'app-add-advertisement',
  templateUrl: './add-advertisement.component.html',
  styleUrls: ['./add-advertisement.component.scss']
})
export class AddAdvertisementComponent implements OnInit {
  public startAt = new Date();
  public min = new Date();
  advertisement: Advertisement = {
    Title: '',
    SportType: 0,
    Date: new Date(),
    Localization: {
      Street: '',
      StreetNumber: 0,
      City: ''
    },
    AgeRange: 0,
    ExtraInformation: '',
    LevelUser: 0,
    UserId: localStorage.getItem('userId')
  };
  time = { hour: 13, minute: 30 };

  constructor(
    private router: Router,
    private advertisementService: AdvertisementService
  ) { }

  ngOnInit() { }
  navigate() {
    this.router.navigateByUrl('user/ownAdvertisement');
  }
  saveAdvertisement() {
    this.advertisementService.addAdvertisement(this.advertisement).subscribe(
      () => {
        this.navigate();
      }
    );
  }
}
