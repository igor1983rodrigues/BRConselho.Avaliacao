import { Subscription, Observable } from 'rxjs';
import { Component, OnInit, OnDestroy } from '@angular/core';

import { Aluno } from './../entities/aluno.entity';
import { AlunoService } from './aluno.service';
import { BaseComponent } from '../shared/base.component';
import { faEdit, faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { Router, ActivatedRoute } from '@angular/router';
import { LoadScreenService } from '../shared/loadscreen/loadscreen.service';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
  styleUrls: ['./aluno.component.css']
})
export class AlunoComponent extends BaseComponent<Aluno> implements OnInit, OnDestroy {
  alunos: Aluno[];
  icons: { edit, delete };
  emmited: Subscription;
  mostrandoMaiores: boolean;

  constructor(
    private alunoService: AlunoService,
    router: Router,
    route: ActivatedRoute
  ) {
    super(router, route);
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
      LoadScreenService.start();
      const inscr = this.alunoService.delete(id).subscribe(
        res => {
          LoadScreenService.stop();
          alert(res.message);
          this.loadAlunos();
        },
        ({ error }) => {
          alert(error.message);
          LoadScreenService.stop();
        },
        () => {
          LoadScreenService.stop();
          inscr.unsubscribe();
        }
      );
    }
  }

  private get getUrlSubscribe(): Observable<Aluno[]> {
    if (this.mostrandoMaiores) {
      return this.alunoService.getMaiores();
    } else {
      return this.alunoService.getAll();
    }
  }

  loadAlunos(): void {
    LoadScreenService.start();
    const inscr = this.getUrlSubscribe.subscribe(
      (res: Aluno[]) => {
        LoadScreenService.stop();
        this.alunos = res;
      },
      ({ error }) => {
        LoadScreenService.stop();
        alert(error.message);
      },
      () => {
        LoadScreenService.stop();
        inscr.unsubscribe();
      }
    );
  }

  ngOnDestroy(): void {
    delete this.alunos;
    this.emmited.unsubscribe();
  }
}
