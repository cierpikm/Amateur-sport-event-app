import { AdvertisementHistoryService } from './../../shared/advertisementHistory.service';
import { Component, OnInit, Input } from '@angular/core';
import { AdvertisementService } from 'src/app/shared/advertisement.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-advertisement-history',
  templateUrl: './advertisement-history.component.html',
  styleUrls: ['./advertisement-history.component.scss']
})
export class AdvertisementHistoryComponent implements OnInit {
  @Input() otherUser = false;
  advertisements = [];
  constructor(private advertisementHistoryService: AdvertisementHistoryService) { }

  ngOnInit() {
    this.advertisementHistoryService.getAllOneAdvertisement().pipe(
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
