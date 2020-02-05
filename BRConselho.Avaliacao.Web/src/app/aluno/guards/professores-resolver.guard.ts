import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs';

import { ProfessorService } from './../../professor/professor.service';
import { Professor } from './../../entities/professor.entity';

@Injectable({
  providedIn: 'root'
})
export class ProfessoresResolverGuard implements Resolve<Professor[]> {
  /**
   *
   */
  constructor(private service: ProfessorService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Professor[] | Observable<Professor[]> {
    return this.service.getAll();
  }
}
