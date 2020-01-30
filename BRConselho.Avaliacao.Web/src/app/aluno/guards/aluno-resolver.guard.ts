import { AlunoService } from './../aluno.service';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Aluno } from 'src/app/entities/aluno.entity';

@Injectable({
  providedIn: 'root'
})
export class AlunoResolverGuard implements Resolve<Aluno> {
  /**
   *
   */
  constructor(private service: AlunoService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Aluno | Observable<Aluno> {
    if (!!route.params && !!route.params.id) {
      return this.service.getById(route.params.id);
    }

    return of<Aluno>({});
  }
}
