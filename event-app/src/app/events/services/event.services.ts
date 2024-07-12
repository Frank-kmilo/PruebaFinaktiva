import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root',
})

export class EventService {

  api = "https://localhost:7083/api/EventLog";

  constructor(private http: HttpClient) {
  }

  saveEvent(event: any) {
    const requestUrl = `${this.api}/add-log`;
    return this.http.post<string>(requestUrl, event).pipe(
      map((res: string) => {
        return res;
      })
    );
  }

  getEventByFilter(type: string, startDate: any, endDate: any){
    const requestUrl = `${this.api}/Get-Events/${type}/${startDate}/${endDate}`;
    return this.http.get<any>(requestUrl).pipe(
      map((res: any) => {
        return res;
      })
    );
  }
}
