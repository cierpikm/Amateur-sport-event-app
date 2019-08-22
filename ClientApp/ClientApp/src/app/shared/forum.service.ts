import { Forum } from './../models/Forum/forum';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Post } from '../models/Forum/post';

@Injectable()
export class ForumService {
  readonly url = 'https://localhost:44352/api/Forum';
  constructor(private http: HttpClient) {}
  getForum(advertisemntId): Observable<Forum> {
    return this.http.get(this.url + '/GetForum/' + advertisemntId).pipe(
      map((res: Forum) => res)
    );
  }
  addPost(post: Post) {
    return this.http.post(this.url + '/SendPost', post);
  }
}
