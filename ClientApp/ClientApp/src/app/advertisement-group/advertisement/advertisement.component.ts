import { AdvertisementService } from '../../shared/advertisement.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Sports } from '../../models/sports';
import { LevelUser } from '../../models/levelUser';
import { Router } from '@angular/router';


@Component({
  selector: 'app-advertisement',
  templateUrl: './advertisement.component.html',
  styleUrls: ['./advertisement.component.scss']
})
export class AdvertisementComponent implements OnInit {
  @Input() advertisement;
  @Input() ownAdvertisement = false;
  @Output() valueChange = new EventEmitter<number>();
  @Input() showedItem;
  @Input() showForum = false;
  showMore = false;
  constructor(
    private advertisementService: AdvertisementService,
    private router: Router
  ) { }

  ngOnInit() { }
  toSportsEnum(sports: Sports) {
    return Sports[sports];
  }
  toLevelUserEnum(levelUser: LevelUser) {
    return LevelUser[levelUser];
  }
  acceptedAdvertisement(advrtisementId) {
    this.valueChange.emit(this.showedItem + 1);
    this.advertisementService
      .addMemberToAdvertisement(advrtisementId);
  }
  discardAdveritesement() {
    this.valueChange.emit(this.showedItem + 1);
  }
  navigateToUser(username) {
    this.router.navigateByUrl('user/users/' + username);
  }
  onClickMe() {
    this.showMore = true;
  }
  public createImgPath = (serverPath: string) => {
    return `https://localhost:44352/${serverPath}`;
  }
}
