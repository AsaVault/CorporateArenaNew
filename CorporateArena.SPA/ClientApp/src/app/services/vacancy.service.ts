import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Vacancy, JobCategory, JobType } from '../models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class VacancyService {
  requestUrl = 'https://localhost:44369';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private http: HttpClient) {}

  getVacancies(): Observable<Vacancy[]> {
    return this.http.get<Vacancy[]>(`${this.requestUrl}/vacancy`);
  }

  getJobCategories(): Observable<JobCategory[]> {
    return this.http.get<JobCategory[]>(`${this.requestUrl}/jobcategory`);
  }

  getJobTypes(): Observable<JobType[]> {
    return this.http.get<JobType[]>(`${this.requestUrl}/jobtype`);
  }
}
