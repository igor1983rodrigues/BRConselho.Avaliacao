import { ProfessorResolverGuard } from './guards/professor-resolver.guard';
import { ProfessorFormComponent } from './professor-form/professor-form.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProfessorComponent } from './professor.component';

const routes: Routes = [{
  path: '',
  component: ProfessorComponent,
  children: [
    { path: 'novo', component: ProfessorFormComponent, resolve: { professor: ProfessorResolverGuard } },
    { path: ':id', component: ProfessorFormComponent, resolve: { professor: ProfessorResolverGuard } },
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfessorRoutingModule { }
