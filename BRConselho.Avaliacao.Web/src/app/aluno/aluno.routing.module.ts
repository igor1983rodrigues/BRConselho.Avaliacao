import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AlunoComponent } from './aluno.component';
import { ProfessoresResolverGuard } from './guards/professores-resolver.guard';
import { AlunoResolverGuard } from './guards/aluno-resolver.guard';
import { AlunoFormComponent } from './aluno-form/aluno-form.component';

const routes: Routes = [{
  path: '',
  component: AlunoComponent,
  children: [
    {
      path: 'novo', component: AlunoFormComponent, resolve: {
        aluno: AlunoResolverGuard,
        professores: ProfessoresResolverGuard
      }
    },
    {
      path: ':id',
      component: AlunoFormComponent,
      resolve:
      {
        aluno: AlunoResolverGuard,
        professores: ProfessoresResolverGuard
      }
    },
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AlunoRoutingModule { }
