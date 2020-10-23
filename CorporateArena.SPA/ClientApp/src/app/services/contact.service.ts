import { ApiUrls } from './../app-config';

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ContactService {
  private apiURL = ApiUrls.ApiURL;
  contactUrl = `${this.apiURL}Contact`;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private http: HttpClient) {}

  get(slug: string): Observable<any> {
    return this.http.get<any>(`${this.contactUrl}/${slug}`);
  }

  postContact(data: any): Observable<any> {
    return this.http.post(
      `${this.contactUrl}/SendMessage`,
      data,
      this.httpOptions
    );
  }
}
