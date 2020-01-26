import { Aluno } from './../../entities/aluno.entity';
import { AlunoService } from './../aluno.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-aluno-form',
  templateUrl: './aluno-form.component.html',
  styleUrls: ['./aluno-form.component.css']
})
export class AlunoFormComponent implements OnInit, OnDestroy {
  private inscricao: Subscription;
  model: Aluno;

  constructor(
    private route: ActivatedRoute,
    private alunoService: AlunoService
  ) {
    this.model = { pessoa: {} };
  }

  ngOnInit() {
    this.inscricao = this.route.params.subscribe(({ id }) => {
      if (!!id) {
        this.alunoService.getById(id).subscribe(
          res => this.model = res,
          error => console.error(error),
          () => console.log('Finish')
        );
      }
    });
  }

  save(): void {
    if (!!this.model.idPessoa && this.model.idPessoa > 0) {
      this.alunoService.put(this.model.idPessoa, this.model);
    } else {
      this.alunoService.post(this.model);
    }
  }

  ngOnDestroy(): void {
    this.inscricao.unsubscribe();
    delete this.inscricao;
  }
}
