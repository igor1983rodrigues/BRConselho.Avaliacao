import { LoadScreenService } from './../shared/loadscreen/loadscreen.service';
import { Subscription, Observable } from 'rxjs';
import { ProfessorService } from './professor.service';
import { Professor } from './../entities/professor.entity';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { BaseComponent } from '../shared/base.component';
import { faEdit, faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-professor',
  templateUrl: './professor.component.html',
  styleUrls: ['./professor.component.css']
})
export class ProfessorComponent extends BaseComponent<Professor> implements OnInit, OnDestroy {
  icons: { edit, delete };
  professores: Professor[];
  emmited: Subscription;
  porFaixaEtaria: boolean;

  constructor(
    private professorService: ProfessorService,
    router: Router,
    route: ActivatedRoute
  ) {
    super(router, route);
    this.porFaixaEtaria = false;
    this.icons = {
      edit: faEdit,
      delete: faTrashAlt
    };
  }

  ngOnInit() {

    this.emmited = this.professorService.emmit.subscribe(
      res => this.loadProfessores()
    );

    this.isEdit = false;
    this.loadProfessores();
  }

  editar(id: number) {
    this.router.navigate([id], {
      relativeTo: this.route
    });
  }

  excluir(id) {
    if (confirm('Deseja mesmo excluir o item?')) {
      const inscr = this.professorService.delete(id).subscribe(
        res => alert(res.message),
        ({ error }) => alert(error.message),
        () => inscr.unsubscribe()
      );
    }
  }

  private get subscribeProgessor(): Observable<Professor[]> {
    if (this.porFaixaEtaria) {
      return this.professorService.getByFaixaEtaria(15, 17);
    } else {
      return this.professorService.getAll();
    }
  }

  loadProfessores(): void {
    LoadScreenService.start();
    const inscr = this.subscribeProgessor.subscribe(
      (res: Professor[]) => {
        LoadScreenService.stop();
        this.professores = res;
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
    delete this.professores;
    this.emmited.unsubscribe();
  }
}
