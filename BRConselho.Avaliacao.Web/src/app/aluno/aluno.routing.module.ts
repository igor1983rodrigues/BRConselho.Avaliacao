import { AlunoResolverGuard } from './guards/aluno-resolver.guard';
import { AlunoFormComponent } from './aluno-form/aluno-form.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AlunoComponent } from './aluno.component';

const routes: Routes = [{
  path: '',
  component: AlunoComponent,
  children: [
    { path: 'novo', component: AlunoFormComponent, resolve: { aluno: AlunoResolverGuard } },
    { path: ':id', component: AlunoFormComponent, resolve: { aluno: AlunoResolverGuard } },
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AlunoRoutingModule { }
