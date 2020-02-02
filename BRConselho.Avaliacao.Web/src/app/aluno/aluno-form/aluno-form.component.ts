import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { faCalendar } from '@fortawesome/free-solid-svg-icons';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbCalendar, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';

import { Aluno } from './../../entities/aluno.entity';
import { AlunoService } from './../aluno.service';
import { BaseComponent } from 'src/app/shared/base.component';

@Component({
  selector: 'app-aluno-form',
  templateUrl: './aluno-form.component.html',
  styleUrls: ['./aluno-form.component.css']
})
export class AlunoFormComponent extends BaseComponent<Aluno> implements OnInit, OnDestroy {
  faCalendar = faCalendar;
  form: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private alunoService: AlunoService,
    private fb: FormBuilder,
    private router: Router
  ) {
    super();
  }

  ngOnInit() {
    // const insc: Subscription = this.route.params
    //   .pipe(
    //     map(({ id }) => id),
    //     switchMap(id => this.alunoService.getById(id))
    //   ).subscribe(
    //     res => this.model = res,
    //     error => console.error(error),
    //     () => insc.unsubscribe()
    //   );

    this.isEdit = true;
    this.model = this.route.snapshot.data.aluno as Aluno;

    if (!!this.model.dataNascimentoAluno) {
      this.model.dataNascimentoAluno = new Date(this.model.dataNascimentoAluno);
    }

    this.form = this.fb.group({
      nomePessoa: [this.model.nomePessoa, [Validators.required, Validators.maxLength(96)]],
      dataNascimentoAluno: [this.model.dataNascimentoAluno || new Date(), Validators.required]
    });

  }

  save(): void {
    delete (this.model as any).pessoa;
    this.model.nomePessoa = this.form.get('nomePessoa').value;
    this.model.dataNascimentoAluno = this.form.get('dataNascimentoAluno').value;
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

  voltar(): void {
    this.router.navigate(['..'], { relativeTo: this.route });
  }

  ngOnDestroy(): void {
    this.isEdit = false;
  }
}
