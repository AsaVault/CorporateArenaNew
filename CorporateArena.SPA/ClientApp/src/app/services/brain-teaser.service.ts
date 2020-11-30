import { BrainTeaserRequest } from './../models/BrainTeaserRequest';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BrainTeaser, Comment, CommentRequest } from '../models';
import { Observable } from 'rxjs';
import { ApiUrls } from '../app-config';
import { BrainTeaserAnswer } from '../models/BrainTeaserAnswer';
import { NgxSpinnerService } from 'ngx-spinner';
@Injectable({
  providedIn: 'root',
})
export class BrainTeaserService {
  private apiURL = ApiUrls.ApiURL;
  brainTeaserUrl = `${this.apiURL}BrainTeaser`;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private http: HttpClient, private spinner: NgxSpinnerService) { }

  getAll(): Observable<BrainTeaser[]> {
    this.spinner.show();
    return this.http.get<BrainTeaser[]>(`${this.brainTeaserUrl}/GetAllBrainTeasers`);
    this.spinner.hide();
  }

  get(slug: string): Observable<BrainTeaser> {
    return this.http.get<BrainTeaser>(`${this.brainTeaserUrl}/GetBrainTeaserAndWinner/${slug}`);
  }

  getWithAnswer(slug: string): Observable<BrainTeaser> {
    return this.http.get<BrainTeaser>(`${this.brainTeaserUrl}/GetBrainTeaserAndAnswer/${slug}`);
  }

  postAnswer(id: number, data: BrainTeaserAnswer): Observable<BrainTeaserAnswer> {
    return this.http.post<BrainTeaserAnswer>(
      `${this.brainTeaserUrl}/AnswerBrainTeaser`,
      data,
      this.httpOptions
    );
  }

  approveAnswer(data: BrainTeaserRequest): Observable<BrainTeaserRequest> {
    return this.http.post<BrainTeaserRequest>(
      `${this.brainTeaserUrl}/ApproveBrainTeaserAnswer`,
      data,
      this.httpOptions
    );
  }

  displayWinner(data: BrainTeaserRequest): Observable<BrainTeaserRequest> {
    return this.http.post<BrainTeaserRequest>(
      `${this.brainTeaserUrl}/DisplayBrainTeaserWinner`,
      data,
      this.httpOptions
    );
  }
}
