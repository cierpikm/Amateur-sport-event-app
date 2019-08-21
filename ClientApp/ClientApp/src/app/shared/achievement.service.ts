import { UserService } from './user.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Achievement } from '../models/achievement';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
@Injectable()
export class AchievementService {
  url = 'https://localhost:44352/api/Achievement/';
  constructor(private http: HttpClient) {}
  getAllUserAchievement(): Observable<Achievement[]> {
    return this.http
      .get(this.url + 'GetAllUserAchievement/' + localStorage.getItem('userId'))
      .pipe(
        map((res: Achievement[]) => {
          return res;
        })
      );
  }
  addAchievement(achievement) {
    return this.http.post(this.url + 'AddAchievement', achievement);
  }
  deleteAchievement(id) {
    return this.http.delete(this.url + 'DeleteAchievement/' + id);
  }
  updateAchievement(achievement) {
    return this.http.post(this.url + 'UpdateAchievement', achievement);
  }
}
