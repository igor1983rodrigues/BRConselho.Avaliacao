import { Subscription } from 'rxjs';
import { Component, OnInit, OnDestroy } from '@angular/core';

import { Aluno } from './../entities/aluno.entity';
import { AlunoService } from './aluno.service';
import { BaseComponent } from '../shared/base.component';
import { faEdit, faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
  styleUrls: ['./aluno.component.css']
})
export class AlunoComponent extends BaseComponent<Aluno> implements OnInit, OnDestroy {
  alunos: Aluno[];
  icons: { edit, delete };
  emmited: Subscription;

  constructor(
    private alunoService: AlunoService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    super();
    this.icons = {
      edit: faEdit,
      delete: faTrashAlt
    };

    this.emmited = this.alunoService.emmit.subscribe(
      res => this.loadAlunos()
    );
  }

  ngOnInit() {
    this.isEdit = false;
    this.alunoService.getAll().subscribe(
      res => this.alunos = res,
      error => console.error(error),
      () => console.log('Complete')
    );
  }

  editar(id: number) {
    this.router.navigate([id], {
      relativeTo: this.route
    });
  }

  excluir(id) {
    if (confirm('Deseja mesmo excluir o item?')) {
      const inscr = this.alunoService.delete(id).subscribe(
        res => {
          alert(res.message);
          this.loadAlunos();
        },
        ({ error }) => alert(error.message),
        () => inscr.unsubscribe()
      );
    }
  }

  loadAlunos(): void {
    const inscr = this.alunoService.getAll().subscribe(
      (res: Aluno[]) => this.alunos = res,
      ({error}) => alert(error.message),
      () => inscr.unsubscribe()
    );
  }

  ngOnDestroy(): void {
    delete this.alunos;
    this.emmited.unsubscribe();
  }
}
