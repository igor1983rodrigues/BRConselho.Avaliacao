import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule, NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CalendarModule } from 'primeng/calendar';

import { AlunoRoutingModule } from './aluno.routing.module';
import { AlunoComponent } from './aluno.component';
import { AlunoFormComponent } from './aluno-form/aluno-form.component';
import { AlunoService } from './aluno.service';



@NgModule({
  declarations: [AlunoComponent, AlunoFormComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    CalendarModule,
    NgbModule,
    NgbDatepickerModule,
    FontAwesomeModule,
    AlunoRoutingModule
  ],
  providers: [AlunoService]
})
export class AlunoModule { }
