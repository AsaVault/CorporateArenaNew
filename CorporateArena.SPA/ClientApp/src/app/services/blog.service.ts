import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Blog, Comment, CommentRequest } from '../models';
import { Observable } from 'rxjs';
import { ApiUrls } from '../app-config';

@Injectable({
  providedIn: 'root',
})
export class BlogService {
  private apiURL = ApiUrls.ApiURL;
  blogUrl = `${this.apiURL}Article`;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private http: HttpClient) { }

  getAll(): Observable<Blog[]> {
    return this.http.get<Blog[]>(`${this.blogUrl}/GetArticles`);
  }

  get(slug: string): Observable<Blog> {
    return this.http.get<Blog>(`${this.blogUrl}/GetArticle/${slug}`);
  }

  postArticle(data: Blog): Observable<Blog> {
    return this.http.post<Blog>(
      `${this.blogUrl}/CreateArticle`,
      data,
      this.httpOptions
    );
  }

  postComment(id: number, data: CommentRequest): Observable<Comment> {
    return this.http.post<Comment>(
      `${this.blogUrl}/CommentOnArticle`,
      data,
      this.httpOptions
    );
  }
}
