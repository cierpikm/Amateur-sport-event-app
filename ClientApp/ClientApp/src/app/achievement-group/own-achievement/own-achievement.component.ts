import { AchievementService } from './../../shared/achievement.service';
import { Component, OnInit } from '@angular/core';
import { Achievement } from 'src/app/models/achievement';

@Component({
  selector: 'app-own-achievement',
  templateUrl: './own-achievement.component.html',
  styleUrls: ['./own-achievement.component.scss']
})
export class OwnAchievementComponent implements OnInit {
  achievement = {
    title: '',
    ranking: 0,
    extraInformation: '',
    userId: localStorage.getItem('userId')
  };
  achievements: Achievement[];
  constructor(private achievementService: AchievementService) { }

  ngOnInit() {
    this.achievementService.getAllUserAchievement().subscribe(
      data => {
        this.achievements = data;
      }
    );
  }

}
