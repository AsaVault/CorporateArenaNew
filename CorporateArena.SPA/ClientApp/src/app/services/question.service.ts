import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiUrls } from '../app-config';
import { Question, QuestionOptions } from '../models';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {
  private apiURL = ApiUrls.ApiURL;
  questionUrl = `${this.apiURL}Question`;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

constructor(private http: HttpClient) { }

getAllQuestion(page: number, pageSize: number): Observable<Question[]> {
  return this.http.get<Question[]>(`${this.questionUrl}/${page}/${pageSize}`);
}

getQuestion(slug: string): Observable<Question> {
  return this.http.get<Question>(`${this.questionUrl}/${slug}`);
}

patchQuestion(data: Question): Observable<Question> {
  return this.http.patch<Question>(`${this.questionUrl}/${data.id}`, data, this.httpOptions);
}

postQuestion(data: Question): Observable<Question> {
  return this.http.post<Question>(
    this.questionUrl,
    data,
    this.httpOptions
  );
}

postQuestionOptions(id: number, data: QuestionOptions): Observable<QuestionOptions> {
  return this.http.post<QuestionOptions>(
    `${this.questionUrl}/option/${id}`,
    data,
    this.httpOptions
  );
}
}
