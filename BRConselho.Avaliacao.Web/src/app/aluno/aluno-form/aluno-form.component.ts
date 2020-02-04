import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';
import { faCalendar } from '@fortawesome/free-solid-svg-icons';

import { Aluno } from './../../entities/aluno.entity';
import { AlunoService } from './../aluno.service';
import { BaseComponent } from 'src/app/shared/base.component';
import { Professor } from 'src/app/entities/professor.entity';

@Component({
  selector: 'app-aluno-form',
  templateUrl: './aluno-form.component.html',
  styleUrls: ['./aluno-form.component.css']
})
export class AlunoFormComponent extends BaseComponent<Aluno> implements OnInit, OnDestroy {
  faCalendar = faCalendar;
  form: FormGroup;
  professores: Professor[];

  constructor(
    private alunoService: AlunoService,
    private fb: FormBuilder,
    route: ActivatedRoute,
    router: Router
  ) {
    super(router, route);
  }

  ngOnInit() {
    this.isEdit = true;
    this.model = this.route.snapshot.data.aluno as Aluno;
    this.professores = this.route.snapshot.data.professores as Professor[];

    if (!!this.model.dataNascimentoAluno) {
      this.model.dataNascimentoAluno = new Date(this.model.dataNascimentoAluno);
    }

    this.model.professor = this.model.professor || {};
    this.form = this.fb.group({
      nomePessoa: [this.model.nomePessoa, [Validators.required, Validators.maxLength(96)]],
      professor: [this.model.professor.idPessoa, [Validators.required]],
      dataNascimentoAluno: [this.model.dataNascimentoAluno || new Date(), Validators.required]
    });

  }

  save(): void {
    delete (this.model as any).pessoa;
    this.model.nomePessoa = this.form.get('nomePessoa').value;
    this.model.dataNascimentoAluno = this.form.get('dataNascimentoAluno').value;
    this.model.professor = { idPessoa: this.form.get('professor').value };
    if (!!this.model.idPessoa && this.model.idPessoa > 0) {
      this.update();
    } else {
      this.create();
    }
  }

  private resultCreateOrUpdate(message: string): void {
    alert(message);
    this.alunoService.emmit.emit(true);
    this.voltar();
  }

  private create(): void {
    const insc: Subscription = this.alunoService
      .post(this.model)
      .subscribe(
        res => this.resultCreateOrUpdate(res.message),
        error => console.error(error),
        () => insc.unsubscribe());
  }

  private update(): void {
    const insc: Subscription = this.alunoService
      .put(this.model.idPessoa, this.model)
      .subscribe(
        res => this.resultCreateOrUpdate(res.message),
        error => console.error(error),
        () => insc.unsubscribe());
  }

  ngOnDestroy(): void {
    this.isEdit = false;
  }
}
