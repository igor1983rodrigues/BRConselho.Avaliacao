import { Subscription } from 'rxjs';
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

  constructor(
    private professorService: ProfessorService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    super();
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
    this.professorService.getAll().subscribe(
      res => this.professores = res,
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
      const inscr = this.professorService.delete(id).subscribe(
        res => alert(res.message),
        ({ error }) => alert(error.message),
        () => inscr.unsubscribe()
      );
    }
  }

  loadProfessores(): void {
    const inscr = this.professorService.getAll().subscribe(
      (res: Professor[]) => this.professores = res,
      ({error}) => alert(error.message),
      () => inscr.unsubscribe()
    );
  }

  ngOnDestroy(): void {
    delete this.professores;
    this.emmited.unsubscribe();
  }
}
