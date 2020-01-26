import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProfessorRoutingModule } from './professor.routing.module';
import { ProfessorComponent } from './professor.component';
import { ProfessorFormComponent } from './professor-form/professor-form.component';


@NgModule({
  declarations: [ProfessorComponent, ProfessorFormComponent],
  imports: [
    CommonModule,
    ProfessorRoutingModule
  ]
})
export class ProfessorModule { }
