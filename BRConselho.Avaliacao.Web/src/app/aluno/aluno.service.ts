import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Aluno } from './../entities/aluno.entity';
import { BaseService } from './../shared/base.service';

@Injectable({
  providedIn: 'root'
})
export class AlunoService extends BaseService<Aluno> {
  constructor(httpClient: HttpClient) {
    super(httpClient, 'aluno');
  }

  getMaiores(): Observable<Aluno[]> {
    return this.getPartial('maiores');
  }
}
