import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProfessorRoutingModule } from './professor.routing.module';
import { ProfessorComponent } from './professor.component';
import { ProfessorFormComponent } from './professor-form/professor-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';


@NgModule({
  declarations: [ProfessorComponent, ProfessorFormComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    FontAwesomeModule,
    ProfessorRoutingModule
  ]
})
export class ProfessorModule { }
