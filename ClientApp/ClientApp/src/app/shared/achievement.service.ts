import { UserService } from './user.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
@Injectable()
export class AchievementService {
   url = 'https://localhost:44378/api/Achievement/';
   constructor(private http: HttpClient, private userService: UserService) {}
  getAllUserAchievement() {
    return this.http.get(this.url + 'GetAllUserAchievement/' + localStorage.getItem('userId'));
  }
  addAchievement(achievement) {
    return this.http.post(this.url + 'AddAchievement', achievement);
  }
  deleteAchievement(id) {
    return this.http.delete(this.url + 'DeleteAchievement/' + id);
  }
}
