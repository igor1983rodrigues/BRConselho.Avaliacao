import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

import { environment } from './../../environments/environment';
import { EventEmitter } from '@angular/core';

export class BaseService<T extends any> {

  emmit: EventEmitter<boolean>;

  private get Url(): string {
    return `${environment.apiUrl}/${this.urlApi}`;
  }

  private get contentTypeJson(): HttpHeaders {
    return new HttpHeaders({'Content-Type': 'application/json'});
  }

  constructor(private httpClient: HttpClient, private urlApi: string) {
    this.emmit = new EventEmitter(true);
  }

  getAll(): Observable<T[]> {
    return this.httpClient.get<T[]>(this.Url);
  }

  getById(id: number): Observable<T> {
    return this.httpClient.get<T>(`${this.Url}/${id}`).pipe(take(1));
  }

  // getByFilter(filter: any): Observable<T> {
  //   return this.httpClient.get<T>(this.Url);
  // }

  post(model: T): Observable<any> {
    const jsonModel = JSON.stringify(model);
    return this.httpClient.post(this.Url, jsonModel, {
      headers: this.contentTypeJson
    });
  }

  put(id: number, model: T): Observable<any> {
    const jsonModel = JSON.stringify(model);
    return this.httpClient.put(`${this.Url}/${id}`, jsonModel, {
      headers: this.contentTypeJson,
      responseType: 'json'
    });
  }

  delete(id: number): Observable<any> {
    return this.httpClient.delete(`${this.Url}/${id}`);
  }
}
