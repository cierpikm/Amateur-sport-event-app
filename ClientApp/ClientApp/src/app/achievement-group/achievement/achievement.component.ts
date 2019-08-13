import { AchievementService } from '../../shared/achievement.service';
import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-achievement',
  templateUrl: './achievement.component.html',
  styleUrls: ['./achievement.component.scss']
})
export class AchievementComponent implements OnInit {
  @Input() onClickViewer = false;
  update = false;
  achievement = {
    title: '',
    ranking: 1,
    extraInformation: '',
    userId: localStorage.getItem('userId')
  };
  @Input() achievements;
  constructor(
    private achievementService: AchievementService,
    private router: Router
  ) {}

  ngOnInit() {}
  addAchievement() {
    this.achievementService.addAchievement(this.achievement).subscribe(
      data => {
        console.log(data);
        this.router
          .navigateByUrl('/user/achievement', { skipLocationChange: true })
          .then(() => this.router.navigate(['/user/ownAchievement']));
      },
      error => {
        console.log(error);
      }
    );
  }
  deleteAchievement(id) {
    this.achievementService.deleteAchievement(id).subscribe(
      data => {
        console.log(data);
        this.router
          .navigateByUrl('/user/achievement', { skipLocationChange: true })
          .then(() => this.router.navigate(['/user/ownAchievement']));
      },
      error => {
        console.log(error);
      }
    );
  }
  updateAchievement(achievement) {
    this.update = true;
    this.achievement = achievement;
  }
  clearAchievement() {
    this.achievement = {
      title: '',
      ranking: 1,
      extraInformation: '',
      userId: localStorage.getItem('userId')
    };
  }
  saveAchievement() {
    this.achievementService.updateAchievement(this.achievement).subscribe(
      data => {
        console.log(data);
        this.router
          .navigateByUrl('/user/achievement', { skipLocationChange: true })
          .then(() => this.router.navigate(['/user/ownAchievement']));
      },
      error => {
        console.log(error);
      }
    );
  }
}
