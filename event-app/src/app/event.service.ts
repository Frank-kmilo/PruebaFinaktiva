import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  private baseUrl = 'https://localhost:7083/api/EventLog';

  constructor(private http: HttpClient) { }

  getAllEvents(): Observable<any> {
    return this.http.get(`${this.baseUrl}/get-all`);
  }

  saveEvent(eventData: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/save`, eventData);
  }
}
