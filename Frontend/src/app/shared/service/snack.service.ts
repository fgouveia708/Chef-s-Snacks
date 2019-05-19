import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map, catchError } from 'rxjs/operators';
import { throwError, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SnackService {

  constructor(
    private client: HttpClient
  ) { }

  apiBaseURL = environment.API_URL;


  get(): Observable<Snack[]> {
    const url = this.apiBaseURL + 'Snacks';
    return this.client.get<Snack[]>(url).pipe(
      map(response => {
        return response;
      }),
      catchError((error: any) => throwError(error))
    );
  }

  getPrice(id: string): Observable<Price> {
    const url = this.apiBaseURL + 'Snacks/Price/';
    return this.client.get<Price>(url + id).pipe(
      map(response => {
        return response;
      }),
      catchError((error: any) => throwError(error))
    );
  }
}
