import { Component, OnInit } from '@angular/core';
import { AdvertisementService } from 'src/app/shared/advertisement.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-accepted-advertisement',
  templateUrl: './accepted-advertisement.component.html',
  styleUrls: ['./accepted-advertisement.component.scss']
})
export class AcceptedAdvertisementComponent implements OnInit {
  advertisements = [];

  constructor(private advertisementService: AdvertisementService) { }

  ngOnInit() {
    this.advertisementService.getAllAcceptedAdvertisements().pipe(
      map((advertisements: []) => {
        return advertisements;
      })
    ).subscribe(
      advertisements => {
        for (const i of advertisements) {
          this.advertisements.push(i);
        }
        console.log(advertisements);
      },
      error => {
        console.log(error);
      }
    );
  }

}
