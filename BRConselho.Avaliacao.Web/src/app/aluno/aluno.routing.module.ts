import { AlunoFormComponent } from './aluno-form/aluno-form.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AlunoComponent } from './aluno.component';

const routes: Routes = [{
  path: '',
  component: AlunoComponent,
  children: [
    { path: 'novo', component: AlunoFormComponent },
    { path: ':id', component: AlunoFormComponent },
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AlunoRoutingModule { }
