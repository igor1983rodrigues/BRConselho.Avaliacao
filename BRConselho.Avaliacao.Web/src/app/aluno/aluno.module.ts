import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgbModule, NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AlunoRoutingModule } from './aluno.routing.module';
import { AlunoComponent } from './aluno.component';
import { AlunoFormComponent } from './aluno-form/aluno-form.component';
import { AlunoService } from './aluno.service';



@NgModule({
  declarations: [AlunoComponent, AlunoFormComponent],
  imports: [
    CommonModule,
    FormsModule,
    NgbModule,
    NgbDatepickerModule,
    FontAwesomeModule,
    AlunoRoutingModule
  ],
  providers: [AlunoService]
})
export class AlunoModule { }
