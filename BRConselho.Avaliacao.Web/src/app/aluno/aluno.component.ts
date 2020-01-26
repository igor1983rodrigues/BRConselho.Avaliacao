import { Component, OnInit, OnDestroy } from '@angular/core';

import { Aluno } from './../entities/aluno.entity';
import { AlunoService } from './aluno.service';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
  styleUrls: ['./aluno.component.css']
})
export class AlunoComponent implements OnInit, OnDestroy {
  alunos: Aluno;

  constructor(private alunoService: AlunoService) { }

  ngOnInit() {
    this.alunoService.getAll().subscribe(
      res => this.alunos = res,
      error => console.error(error),
      () => console.log('Complete')
    );
  }

  ngOnDestroy(): void {
    delete this.alunos;
  }
}
