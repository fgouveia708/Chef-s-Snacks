import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map, catchError } from 'rxjs/operators';
import { throwError, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IngredientService {

  constructor(
    private client: HttpClient
  ) { }

  apiBaseURL = environment.API_URL;

  get(): Observable<Ingredient[]> {
    const url = this.apiBaseURL + 'Ingredients';
    return this.client.get<Ingredient[]>(url).pipe(
      map(response => {
        return response;
      }),
      catchError((error: any) => throwError(error))
    );
  }

  getPricePromotion(id: string, amount: number): Observable<number> {
    const url = this.apiBaseURL + 'Ingredients/PricePromotion/';
    return this.client.get<number>(url + id + '/' + amount).pipe(
      map(response => {
        return response;
      }),
      catchError((error: any) => throwError(error))
    );
  }

  getPricePromotionTotal(pricePromotion: PricePromotion): Observable<number> {
    const url = this.apiBaseURL + 'Ingredients/PricePromotion';
    return this.client.post<number>(url, pricePromotion).pipe(
      map(response => {
        return response;
      }),
      catchError((error: any) => throwError(error))
    );
  }
}
