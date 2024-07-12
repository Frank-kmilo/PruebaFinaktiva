import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root',
})
export class EventService {

  api = "https://localhost:7083/api/EventLog";

  constructor(private http: HttpClient) {
  }

  saveEvent(event: any) : Observable<string> {
    const requestUrl = `${this.api}/add-log`;
    return this.http.post<string>(requestUrl, event,{ responseType: 'text' as 'json'  });
  }

  getEventByFilter(type: string, startDate: any, endDate: any){

    let requestUrl = `${this.api}/Get-Events`;

    const params = new URLSearchParams();
    if (type) {
      params.append('type', type);
    }
    if (startDate) {
      params.append('startdate', this.formatDate(startDate));
    }
    if (endDate) {
      params.append('enddate', this.formatDate(endDate));
    }

    if (params.toString()) {
      requestUrl = `${requestUrl}?${params.toString()}`;
    }

    return this.http.get<any>(requestUrl).pipe(
      map((res: any) => {
        return res;
      })
    );
  }

  private formatDate(date: Date): string {
    const year = date.getFullYear();
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const day = date.getDate().toString().padStart(2, '0');
    return `${year}-${month}-${day}`;
  }
}
