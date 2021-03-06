import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Professor } from './../entities/professor.entity';
import { BaseService } from './../shared/base.service';
import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProfessorService extends BaseService<Professor> {
  constructor(httpClient: HttpClient) {
    super(httpClient, 'professor');
  }

  getByFaixaEtaria(from: number, to: number): Observable<Professor[]> {
    return this.getPartial(`idadealuno/${from}/${to}`);
  }
}
