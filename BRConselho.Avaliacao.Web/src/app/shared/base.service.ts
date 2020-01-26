import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export class BaseService<T> {
  private get Url(): string {
    return `${environment.apiUrl}/${this.urlApi}`;
  }

  constructor(private httpClient: HttpClient, private urlApi: string) {}

  getAll(): Observable<T[]> {
    return this.httpClient.get<T[]>(this.Url);
  }

  getById(id: number): Observable<T> {
    return this.httpClient.get<T>(`${this.Url}/${id}`);
  }

  // getByFilter(filter: any): Observable<T> {
  //   return this.httpClient.get<T>(this.Url);
  // }

  post(model: T): Observable<any> {
    const jsonModel = JSON.stringify(model);
    return this.httpClient.post(this.Url, jsonModel);
  }

  put(id: number, model: T): Observable<any> {
    const jsonModel = JSON.stringify(model);
    return this.httpClient.put(`${this.Url}/${id}`, jsonModel);
  }

  delete(id: number): Observable<any> {
    return this.httpClient.delete(`${this.Url}/${id}`);
  }
}
