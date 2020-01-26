import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AlunoService } from './aluno.service';
import { AlunoRoutingModule } from './aluno.routing.module';
import { AlunoComponent } from './aluno.component';
import { AlunoFormComponent } from './aluno-form/aluno-form.component';



@NgModule({
  declarations: [AlunoComponent, AlunoFormComponent],
  imports: [
    CommonModule,
    FormsModule,
    NgbModule,
    AlunoRoutingModule
  ],
  providers: [AlunoService]
})
export class AlunoModule { }
