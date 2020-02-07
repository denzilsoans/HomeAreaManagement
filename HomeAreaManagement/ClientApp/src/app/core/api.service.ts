import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Area } from '../model/area.model';
import { ServiceResponse } from '../model/area.serviceResponse.model';
import { Observable, throwError } from 'rxjs/index';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})

export class ApiService {
  private BaseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.BaseUrl = baseUrl;
  }

  getAreaById(id: number): Observable<Area> {
    return this.http.get<Area>(this.BaseUrl + 'Areas/' + id.toLocaleString());
  }

  updateArea(area: Area): Observable<ServiceResponse> {
    return this.http
      .put<ServiceResponse>(this.BaseUrl + 'Areas/' + area.id.toLocaleString(), area)
      .pipe(catchError(this.handleError));
  }

  deleteArea(id: number): Observable<ServiceResponse> {
    return this.http
      .delete<ServiceResponse>(this.BaseUrl + 'Areas/' + id.toLocaleString())
      .pipe(catchError(this.handleError));;
  }

  handleError(error: HttpErrorResponse) {
    let errorMessage = 'Unknown error!';
    if (error.error instanceof ErrorEvent) {
      // Client-side errors
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Server-side errors
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }
}
