import { CommentRequestTrafficUpdate } from './../models/CommentRequestTrafficUpdate';
import { Injectable } from '@angular/core';
import { TrafficUpdate, Comment, CommentRequest } from '../models';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiUrls } from '../app-config';

@Injectable({
  providedIn: 'root',
})
export class TrafficUpdateService {
  private apiURL = ApiUrls.ApiURL;
  trafficUpdateUrl = `${this.apiURL}TrafficUpdate`;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };
  constructor(private http: HttpClient) { }

  getAll(): Observable<TrafficUpdate[]> {
    return this.http.get<TrafficUpdate[]>(`${this.trafficUpdateUrl}/GetAllTrafficUpdates`);
  }

  getBySlug(slug: string): Observable<TrafficUpdate> {
    return this.http.get<TrafficUpdate>(`${this.trafficUpdateUrl}/GetTrafficUpdate/${slug}`);
  }

  postTrafficUpdate(data: TrafficUpdate): Observable<TrafficUpdate> {
    return this.http.post<TrafficUpdate>(
      `${this.trafficUpdateUrl}/SaveTrafficUpdate`,
      data,
      this.httpOptions
    );
  }

  postComment(data: CommentRequestTrafficUpdate): Observable<CommentRequestTrafficUpdate> {
    return this.http.post<CommentRequestTrafficUpdate>(
      `${this.trafficUpdateUrl}/CommentOnTrafficUpdate`,
      data,
      this.httpOptions
    );
  }
}
