import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Professor } from './../../entities/professor.entity';
import { ProfessorService } from '../professor.service';

@Injectable({
  providedIn: 'root'
})
export class ProfessorResolverGuard implements Resolve<Professor> {
  /**
   *
   */
  constructor(private service: ProfessorService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Professor | Observable<Professor> {
    if (!!route.params && !!route.params.id) {
      return this.service.getById(route.params.id);
    }

    return of<Professor>({});
  }
}
