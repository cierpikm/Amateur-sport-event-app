import { AdvertisementService } from './../../shared/advertisement.service';
import { Component, OnInit, Input } from '@angular/core';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-own-advertisement',
  templateUrl: './own-advertisement.component.html',
  styleUrls: ['./own-advertisement.component.scss']
})
export class OwnAdvertisementComponent implements OnInit {
  @Input() otherUser = false;
  advertisements = [];
  constructor(private advertisementService: AdvertisementService, private router: Router) { }

  ngOnInit() {
    this.advertisementService.getAllOneAdvertisement().pipe(
      map((advertisements: []) => {
        return advertisements;
      })
    ).subscribe(
      advertisements => {
        for (const i of advertisements) {
          this.advertisements.push(i);
        }
      }
    );
  }

  addAdvertisement() {
    this.router.navigateByUrl('/user/addAdvertisement');
  }
}
