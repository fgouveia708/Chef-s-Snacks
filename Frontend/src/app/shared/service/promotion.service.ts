import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { throwError, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PromotionService {

  constructor(
    private client: HttpClient
  ) { }

  apiBaseURL = environment.API_URL;


  get(): Observable<Promotion[]> {
    const url = this.apiBaseURL + 'Promotions';
    return this.client.get<Promotion[]>(url).pipe(
      map(response => {
        return response;
      }),
      catchError((error: any) => throwError(error))
    );
  }
}
